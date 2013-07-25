using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbAccessLibTest.Test;

namespace DbAccessLibTest
{
    public partial class FrmDbAccessTest : Form
    {
        private string _executeType = "Insert";//测试查询类型
        private string _testLibClassPath = "DbAccessLibTest.Test.ClownFishTest";//测试组件类路径
        private long _totalElapsed;//总耗时
        private int _workThreadCount;//工作线程数
        private int _threadCountCreated, _threadCountBack;
        private int _executeCount;//执行查询次数（返回行数）
        private bool _showThreadWorkStatus;
        private Dictionary<int, List<string>> _guidList;//执行删除和修改时，预先取回的主键guid集合，按照每个线程序号分组分配
        private List<Worker> _workerInfo;//测试工作线程信息，主要用于图表数据显示
        private ITest _testInstance;//用于准备执行删除、修改的guid集合
        private DateTime _beginTime;//测试开始的时间
        private readonly AutoResetEvent _waitWrite = new AutoResetEvent(true);//编辑总耗时等全局信息的信号灯
        private CancellationTokenSource _taskCancelToken;
        private readonly Assembly _self = Assembly.Load("数据访问组件测试");
        public FrmDbAccessTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _workerInfo = new List<Worker>();
            chartMain.Series[0].XValueMember = "Name";
            chartMain.Series[0].YValueMembers = "TotalElapsed";
            chartMain.DataSource = _workerInfo;
        }
        /// <summary>
        /// 执行测试
        /// </summary>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //初始化数据
            _workThreadCount = (int)nuWorkThreadCount.Value;
            _executeCount = (int)nuExecuteCount.Value;
            _totalElapsed = 0;
            _workerInfo = new List<Worker>();
            _testLibClassPath = "DbAccessLibTest.Test." + cmbTestLib.Text;
            _testInstance = (ITest)_self.CreateInstance(_testLibClassPath);
            _beginTime = DateTime.Now;
            UpdateMessage(string.Format("测试开始时间：{0}", DateTime.Now));
            UpdateMessage(string.Format("  启动线程数：{0}", _workThreadCount));
            UpdateMessage(string.Format("  执行操作数：{0}", _executeCount));
            btnExecute.Enabled = false;
            nuThreadCountBack.Value = _threadCountBack = 0;
            nuThreadCountCreated.Value = _threadCountCreated = 0;
            _showThreadWorkStatus = ckbShowThreadStatus.Checked;
            ckbShowThreadStatus.Enabled = false;

            new Thread(TestMain).Start();
        }

        private void TestMain()
        {
            try
            {
                UpdateMessage(string.Format("数据准备开始：{0}", DateTime.Now));
                Action<ITest, int> testExecute = GetExecuteUse();
                UpdateMessage(string.Format("数据准备结束：{0}", DateTime.Now));
                int createCount = _workThreadCount;
                UpdateMessage(string.Format("开始创建线程：{0}", DateTime.Now));
                _taskCancelToken = new CancellationTokenSource();
                for (int index = 0; index < createCount; index++)
                {
                    if (IsDisposed)
                        return;//防止重启程序时，仍然不断创建线程
                    if (rdbThreadPool.Checked)
                        UseThreadPool(index, testExecute);
                    else if (rdbThread.Checked)
                        UseThread(index, testExecute);
                    else
                    {
                        if (!UseTask(index, testExecute))
                            return;//如果已经重启程序，则跳出
                    }
                    Thread.Sleep(50);
                    UpdateThreadCountCreated();
                }
                UpdateMessage(string.Format("创建线程完毕：{0}", DateTime.Now));
            }
            catch (Exception ex)
            {
                UpdateMessage(ex.Message);
            }
        }
        private void UseThreadPool(int index, Action<ITest, int> testExecute)
        {
            ThreadPool.QueueUserWorkItem(
                                        threadIndex =>
                                            TestWork(threadIndex, testExecute
                                            , (ITest)_self.CreateInstance(_testLibClassPath)), index);
        }
        private void UseThread(int index, Action<ITest, int> testExecute)
        {
            new Thread(
                threadIndex =>
                    TestWork(threadIndex, testExecute
                    , (ITest)_self.CreateInstance(_testLibClassPath)))
                    .Start(index);
        }
        private bool UseTask(int index, Action<ITest, int> testExecute)
        {
            var task = new Task<object>
                (
                    threadIndex => TestWork(threadIndex, testExecute, (ITest)_self.CreateInstance(_testLibClassPath))
                    , index
                    , _taskCancelToken.Token
                );
            if (_taskCancelToken.IsCancellationRequested)
                return false;
            task.Start();
            return true;
        }
        /// <summary>
        /// 执行指定查询的测试，并记录测试数据
        /// </summary>
        /// <param name="index">线程序号</param>
        /// <param name="execute">执行的查询</param>
        /// <param name="instance">执行测试的组件实体</param>
        private object TestWork(object index, Action<ITest, int> execute, ITest instance)
        {

            Stopwatch sw = new Stopwatch();
            string threadName = string.Format("{0:D3}", index);
            if (_showThreadWorkStatus)
                UpdateMessage(string.Format("线程{0}开始时间：{1}", threadName, DateTime.Now));
            sw.Start(); try
            {
                execute(instance, (int)index);
            }
            catch (Exception ex)
            {
                UpdateMessage(string.Format("*线程{0} 执行错误，信息：{1}", threadName, ex.Message));
            }
            sw.Stop();
            if (_showThreadWorkStatus)
                UpdateMessage(string.Format("*线程{0}  *总耗时：{1}   *当前时间：{2}", threadName, sw.ElapsedMilliseconds, DateTime.Now));
            _waitWrite.WaitOne();
            _waitWrite.Reset();
            _workThreadCount--;
            _totalElapsed += sw.ElapsedMilliseconds;
            _workerInfo.Add(new Worker { Name = threadName, TotalElapsed = sw.ElapsedMilliseconds });

            if (_workThreadCount == 0)
            {
                UpdateMessage(string.Format("全部线程总耗时：{0} *开始时间：{1}  *结束时间：{2}", _totalElapsed, _beginTime, DateTime.Now));
                UpdateChart();
                EnableExecuteControl();
            }
            Application.DoEvents();
            UpdateThreadCountBack();
            _waitWrite.Set();
            return 0;
        }
        #region 执行查询

        private void ExecuteInsert(ITest instance, int threadIndex)
        {
            for (int i = 0; i < _executeCount; i++)
                instance.Insert();
        }

        private void ExecuteUpdate(ITest instance, int threadIndex)
        {
            foreach (string guid in _guidList[threadIndex])
                instance.Update(guid, string.Format("测试修改 **线程：{0}**组件：{1}**时间：{2}", threadIndex, instance.GetType(), DateTime.Now));
        }

        private void ExecuteDelete(ITest instance, int threadIndex)
        {
            foreach (string guid in _guidList[threadIndex])
                instance.Delete(guid);
        }

        private void ExecuteSelect(ITest instance, int threadIndex)
        {
            instance.Select(_executeCount);
        }

        #endregion

        /// <summary>
        /// 获取测试的操作，如果是删除和更新，则先准备数据
        /// </summary>
        /// <returns></returns>
        private Action<ITest, int> GetExecuteUse()
        {
            switch (_executeType)
            {
                case "Insert":
                    return ExecuteInsert;
                case "Delete":
                    AssignGuid(); return ExecuteDelete;
                case "Update":
                    AssignGuid(); return ExecuteUpdate;
                case "Select":
                    return ExecuteSelect;
            }
            throw new Exception("程序异常：GetExecute");
        }
        /// <summary>
        /// 获取删除或者更新需要的guid集合，并分配给各个线程
        /// </summary>
        private void AssignGuid()
        {
            var list = _testInstance.GetGuidList(_workThreadCount * _executeCount);
            _guidList = new Dictionary<int, List<string>>(_workThreadCount);
            for (int i = 0; i < _workThreadCount; i++)
                _guidList.Add(i, new List<string>());
            for (int i = 0; i < list.Count; i++)
            {
                int index = i % _workThreadCount;
                _guidList[index].Add(list[i]);
            }
        }
        /// <summary>
        /// 更新图表
        /// </summary>
        private void UpdateChart()
        {
            if (IsDisposed)
                return;
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(UpdateChart));
            else
            {
                if (_workerInfo.Count > 10)
                    chartMain.Series[0].Label = string.Empty;
                _workerInfo.Sort();
                chartMain.DataSource = _workerInfo;
                chartMain.ResetAutoValues();
            }
        }
        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="msg"></param>
        private void UpdateMessage(string msg)
        {
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UpdateMessage(msg)));
            else
            {
                rtxtMessage.AppendText(msg + "\n");
                rtxtMessage.Select(rtxtMessage.Text.Length - 1, 1);
                rtxtMessage.ScrollToCaret();
            }
        }
        /// <summary>
        /// 更新已创建线程数
        /// </summary>
        private void UpdateThreadCountCreated()
        {
            if (IsDisposed)
                return;
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(UpdateThreadCountCreated));
            else
                nuThreadCountCreated.Value = _threadCountCreated = (int)nuThreadCountCreated.Value + 1;
        }
        /// <summary>
        /// 更新返回线程数
        /// </summary>
        private void UpdateThreadCountBack()
        {
            if (IsDisposed)
                return;
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(UpdateThreadCountBack));
            else
                nuThreadCountBack.Value = _threadCountBack = (int)nuThreadCountBack.Value + 1;
        }

        /// <summary>
        /// 启用执行按钮
        /// </summary>
        private void EnableExecuteControl()
        {
            if (IsDisposed)
                return;
            Invoke(new MethodInvoker(() =>
            {
                btnExecute.Enabled = true;
                ckbShowThreadStatus.Enabled = true;
            }));
        }
        private void rdbExecute_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            if (rdb == null)
                throw new Exception("程序异常：rdbExecute_CheckedChanged");
            if (rdb.Checked)
                _executeType = rdb.Text;
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            //暂时没有实现
        }
        private void btnTruncateTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清空整个表吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                btnTruncateTable.Enabled = false;
                new ClownFishTest().TruncateTable();
                UpdateMessage("表已清空 - " + DateTime.Now);
                btnTruncateTable.Enabled = true;
            }
        }

        private void btnThreadInfo_Click(object sender, EventArgs e)
        {
            UpdateMessage(string.Format("线程数：{0}", _workThreadCount));
        }

        private void btnRestartForm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (rdbTask.Checked)
                _taskCancelToken.Cancel(true);
            Close();
            Dispose();
        }
    }
}
