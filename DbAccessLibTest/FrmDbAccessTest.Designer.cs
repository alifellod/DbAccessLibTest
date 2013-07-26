namespace DbAccessLibTest
{
    partial class FrmDbAccessTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nuWorkThreadCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nuExecuteCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbInsert = new System.Windows.Forms.RadioButton();
            this.rdbDelete = new System.Windows.Forms.RadioButton();
            this.rdbUpdate = new System.Windows.Forms.RadioButton();
            this.rdbSelect = new System.Windows.Forms.RadioButton();
            this.btnExecute = new System.Windows.Forms.Button();
            this.rtxtMessage = new System.Windows.Forms.RichTextBox();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbTask = new System.Windows.Forms.RadioButton();
            this.rdbThread = new System.Windows.Forms.RadioButton();
            this.rdbThreadPool = new System.Windows.Forms.RadioButton();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnRestartForm = new System.Windows.Forms.Button();
            this.cmbTestLib = new System.Windows.Forms.ComboBox();
            this.btnTruncateTable = new System.Windows.Forms.Button();
            this.btnThreadInfo = new System.Windows.Forms.Button();
            this.nuThreadCountBack = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nuThreadCountCreated = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ckbShowThreadStatus = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuWorkThreadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuExecuteCount)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuThreadCountBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuThreadCountCreated)).BeginInit();
            this.SuspendLayout();
            // 
            // chartMain
            // 
            chartArea2.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.Maroon;
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.NarrowHorizontal;
            chartArea2.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMain.Legends.Add(legend2);
            this.chartMain.Location = new System.Drawing.Point(21, 12);
            this.chartMain.Name = "chartMain";
            series2.ChartArea = "ChartArea1";
            series2.Label = "#VALX";
            series2.LabelBackColor = System.Drawing.Color.Gainsboro;
            series2.LabelBorderColor = System.Drawing.Color.BlanchedAlmond;
            series2.LabelToolTip = "#VAL{N0}";
            series2.Legend = "Legend1";
            series2.LegendText = "平均：#AVG{N0}";
            series2.LegendToolTip = "平均：#AVG{N0}\\n最高：#MAX{N0}\\n最低：#MIN{N0}";
            series2.Name = "图例";
            series2.XValueMember = "Name";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.YValueMembers = "TotalElapsed";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            this.chartMain.Series.Add(series2);
            this.chartMain.Size = new System.Drawing.Size(776, 256);
            this.chartMain.TabIndex = 1;
            this.chartMain.Text = "chart1";
            // 
            // nuWorkThreadCount
            // 
            this.nuWorkThreadCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuWorkThreadCount.Location = new System.Drawing.Point(383, 284);
            this.nuWorkThreadCount.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nuWorkThreadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuWorkThreadCount.Name = "nuWorkThreadCount";
            this.nuWorkThreadCount.Size = new System.Drawing.Size(82, 21);
            this.nuWorkThreadCount.TabIndex = 2;
            this.ttMain.SetToolTip(this.nuWorkThreadCount, "目前限制最大线程是2000，有兴趣可以修改代码调的更高");
            this.nuWorkThreadCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "线程数：";
            // 
            // nuExecuteCount
            // 
            this.nuExecuteCount.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nuExecuteCount.Location = new System.Drawing.Point(383, 321);
            this.nuExecuteCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nuExecuteCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuExecuteCount.Name = "nuExecuteCount";
            this.nuExecuteCount.Size = new System.Drawing.Size(82, 21);
            this.nuExecuteCount.TabIndex = 2;
            this.ttMain.SetToolTip(this.nuExecuteCount, "每个线程执行的查询操作次数，数目越大，单个线程工作量越大。\r\n如果是查询，则表示查询的行数\r\n");
            this.nuExecuteCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "查询操作数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "查询类型：";
            // 
            // rdbInsert
            // 
            this.rdbInsert.AutoSize = true;
            this.rdbInsert.Checked = true;
            this.rdbInsert.Location = new System.Drawing.Point(93, 355);
            this.rdbInsert.Name = "rdbInsert";
            this.rdbInsert.Size = new System.Drawing.Size(59, 16);
            this.rdbInsert.TabIndex = 5;
            this.rdbInsert.TabStop = true;
            this.rdbInsert.Text = "Insert";
            this.rdbInsert.UseVisualStyleBackColor = true;
            this.rdbInsert.CheckedChanged += new System.EventHandler(this.rdbExecute_CheckedChanged);
            // 
            // rdbDelete
            // 
            this.rdbDelete.AutoSize = true;
            this.rdbDelete.Location = new System.Drawing.Point(154, 356);
            this.rdbDelete.Name = "rdbDelete";
            this.rdbDelete.Size = new System.Drawing.Size(59, 16);
            this.rdbDelete.TabIndex = 5;
            this.rdbDelete.Text = "Delete";
            this.rdbDelete.UseVisualStyleBackColor = true;
            this.rdbDelete.CheckedChanged += new System.EventHandler(this.rdbExecute_CheckedChanged);
            // 
            // rdbUpdate
            // 
            this.rdbUpdate.AutoSize = true;
            this.rdbUpdate.Location = new System.Drawing.Point(216, 356);
            this.rdbUpdate.Name = "rdbUpdate";
            this.rdbUpdate.Size = new System.Drawing.Size(59, 16);
            this.rdbUpdate.TabIndex = 5;
            this.rdbUpdate.Text = "Update";
            this.rdbUpdate.UseVisualStyleBackColor = true;
            this.rdbUpdate.CheckedChanged += new System.EventHandler(this.rdbExecute_CheckedChanged);
            // 
            // rdbSelect
            // 
            this.rdbSelect.AutoSize = true;
            this.rdbSelect.Location = new System.Drawing.Point(278, 356);
            this.rdbSelect.Name = "rdbSelect";
            this.rdbSelect.Size = new System.Drawing.Size(59, 16);
            this.rdbSelect.TabIndex = 5;
            this.rdbSelect.Text = "Select";
            this.rdbSelect.UseVisualStyleBackColor = true;
            this.rdbSelect.CheckedChanged += new System.EventHandler(this.rdbExecute_CheckedChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(715, 351);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(82, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "执行";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // rtxtMessage
            // 
            this.rtxtMessage.Location = new System.Drawing.Point(19, 380);
            this.rtxtMessage.Name = "rtxtMessage";
            this.rtxtMessage.Size = new System.Drawing.Size(778, 124);
            this.rtxtMessage.TabIndex = 7;
            this.rtxtMessage.Text = "具体测试，可以自行修改数据访问操作代码。\n默认线程的创建间隔延迟是50毫秒。\n图表说明：X轴为线程序号、Y轴为耗时。";
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(640, 136);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(75, 23);
            this.btnAnalysis.TabIndex = 6;
            this.btnAnalysis.Text = "分析数据";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Visible = false;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "组件类型：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "线程类型：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbTask);
            this.panel2.Controls.Add(this.rdbThread);
            this.panel2.Controls.Add(this.rdbThreadPool);
            this.panel2.Location = new System.Drawing.Point(88, 281);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 27);
            this.panel2.TabIndex = 9;
            this.ttMain.SetToolTip(this.panel2, "推荐使用Task类型，可以在整崩SQL连接池时，重启程序。\r\n并能在重启前取消已启动线程。其它则不能。");
            // 
            // rdbTask
            // 
            this.rdbTask.AutoSize = true;
            this.rdbTask.Checked = true;
            this.rdbTask.Location = new System.Drawing.Point(6, 7);
            this.rdbTask.Name = "rdbTask";
            this.rdbTask.Size = new System.Drawing.Size(47, 16);
            this.rdbTask.TabIndex = 0;
            this.rdbTask.TabStop = true;
            this.rdbTask.Text = "Task";
            this.rdbTask.UseVisualStyleBackColor = true;
            // 
            // rdbThread
            // 
            this.rdbThread.AutoSize = true;
            this.rdbThread.Location = new System.Drawing.Point(153, 8);
            this.rdbThread.Name = "rdbThread";
            this.rdbThread.Size = new System.Drawing.Size(59, 16);
            this.rdbThread.TabIndex = 0;
            this.rdbThread.Text = "Thread";
            this.rdbThread.UseVisualStyleBackColor = true;
            // 
            // rdbThreadPool
            // 
            this.rdbThreadPool.AutoSize = true;
            this.rdbThreadPool.Location = new System.Drawing.Point(63, 8);
            this.rdbThreadPool.Name = "rdbThreadPool";
            this.rdbThreadPool.Size = new System.Drawing.Size(83, 16);
            this.rdbThreadPool.TabIndex = 0;
            this.rdbThreadPool.Text = "ThreadPool";
            this.rdbThreadPool.UseVisualStyleBackColor = true;
            // 
            // btnRestartForm
            // 
            this.btnRestartForm.Location = new System.Drawing.Point(597, 351);
            this.btnRestartForm.Name = "btnRestartForm";
            this.btnRestartForm.Size = new System.Drawing.Size(82, 23);
            this.btnRestartForm.TabIndex = 6;
            this.btnRestartForm.Text = "重启程序";
            this.ttMain.SetToolTip(this.btnRestartForm, "除了Task外，其它启动的线程并不能销毁");
            this.btnRestartForm.UseVisualStyleBackColor = true;
            this.btnRestartForm.Click += new System.EventHandler(this.btnRestartForm_Click);
            // 
            // cmbTestLib
            // 
            this.cmbTestLib.Items.AddRange(new object[] {
            "ClownFishTest",
            "MoonTest",
            "PdfTest",
            "CyqOrmTest",
            "EFOrmTest",
            "MoonOrmTest",
            "MySoftOrmTest",
            "NHibernateOrmTest",
            "PdfOrmTest",
            "XCodeOrmTest"});
            this.cmbTestLib.Location = new System.Drawing.Point(91, 322);
            this.cmbTestLib.Name = "cmbTestLib";
            this.cmbTestLib.Size = new System.Drawing.Size(209, 20);
            this.cmbTestLib.TabIndex = 0;
            this.cmbTestLib.Text = "ClownFishTest";
            // 
            // btnTruncateTable
            // 
            this.btnTruncateTable.Location = new System.Drawing.Point(715, 320);
            this.btnTruncateTable.Name = "btnTruncateTable";
            this.btnTruncateTable.Size = new System.Drawing.Size(82, 23);
            this.btnTruncateTable.TabIndex = 6;
            this.btnTruncateTable.Text = "清表";
            this.btnTruncateTable.UseVisualStyleBackColor = true;
            this.btnTruncateTable.Click += new System.EventHandler(this.btnTruncateTable_Click);
            // 
            // btnThreadInfo
            // 
            this.btnThreadInfo.Location = new System.Drawing.Point(499, 350);
            this.btnThreadInfo.Name = "btnThreadInfo";
            this.btnThreadInfo.Size = new System.Drawing.Size(75, 23);
            this.btnThreadInfo.TabIndex = 6;
            this.btnThreadInfo.Text = "线程信息";
            this.btnThreadInfo.UseVisualStyleBackColor = true;
            this.btnThreadInfo.Visible = false;
            this.btnThreadInfo.Click += new System.EventHandler(this.btnThreadInfo_Click);
            // 
            // nuThreadCountBack
            // 
            this.nuThreadCountBack.Enabled = false;
            this.nuThreadCountBack.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuThreadCountBack.Location = new System.Drawing.Point(715, 284);
            this.nuThreadCountBack.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nuThreadCountBack.Name = "nuThreadCountBack";
            this.nuThreadCountBack.ReadOnly = true;
            this.nuThreadCountBack.Size = new System.Drawing.Size(82, 21);
            this.nuThreadCountBack.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(662, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "已返回：";
            // 
            // nuThreadCountCreated
            // 
            this.nuThreadCountCreated.Enabled = false;
            this.nuThreadCountCreated.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuThreadCountCreated.Location = new System.Drawing.Point(556, 284);
            this.nuThreadCountCreated.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nuThreadCountCreated.Name = "nuThreadCountCreated";
            this.nuThreadCountCreated.ReadOnly = true;
            this.nuThreadCountCreated.Size = new System.Drawing.Size(82, 21);
            this.nuThreadCountCreated.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(503, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "已创建：";
            // 
            // ckbShowThreadStatus
            // 
            this.ckbShowThreadStatus.AutoSize = true;
            this.ckbShowThreadStatus.Location = new System.Drawing.Point(506, 325);
            this.ckbShowThreadStatus.Name = "ckbShowThreadStatus";
            this.ckbShowThreadStatus.Size = new System.Drawing.Size(96, 16);
            this.ckbShowThreadStatus.TabIndex = 10;
            this.ckbShowThreadStatus.Text = "显示线程状态";
            this.ckbShowThreadStatus.UseVisualStyleBackColor = true;
            // 
            // FrmDbAccessTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 514);
            this.Controls.Add(this.ckbShowThreadStatus);
            this.Controls.Add(this.cmbTestLib);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rtxtMessage);
            this.Controls.Add(this.btnThreadInfo);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.btnTruncateTable);
            this.Controls.Add(this.btnRestartForm);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.rdbSelect);
            this.Controls.Add(this.rdbUpdate);
            this.Controls.Add(this.rdbDelete);
            this.Controls.Add(this.rdbInsert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nuExecuteCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuThreadCountCreated);
            this.Controls.Add(this.nuThreadCountBack);
            this.Controls.Add(this.nuWorkThreadCount);
            this.Controls.Add(this.chartMain);
            this.Name = "FrmDbAccessTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据组件访问测试 - 火地晋";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuWorkThreadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuExecuteCount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuThreadCountBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuThreadCountCreated)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.NumericUpDown nuWorkThreadCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuExecuteCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbInsert;
        private System.Windows.Forms.RadioButton rdbDelete;
        private System.Windows.Forms.RadioButton rdbUpdate;
        private System.Windows.Forms.RadioButton rdbSelect;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.RichTextBox rtxtMessage;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbThreadPool;
        private System.Windows.Forms.RadioButton rdbThread;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.ComboBox cmbTestLib;
        private System.Windows.Forms.Button btnTruncateTable;
        private System.Windows.Forms.Button btnThreadInfo;
        private System.Windows.Forms.NumericUpDown nuThreadCountBack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nuThreadCountCreated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckbShowThreadStatus;
        private System.Windows.Forms.Button btnRestartForm;
        private System.Windows.Forms.RadioButton rdbTask;
    }
}

