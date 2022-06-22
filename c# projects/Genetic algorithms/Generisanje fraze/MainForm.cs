using Generisanje_fraze.Classes;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Generisanje_fraze
{
    public partial class frmMain : Form
    {

        #region Attributes

        private Random rnd;
        private Thread thread;
        private bool isRunning;
        private bool isCreated;
        private bool isFinished;
        private Population pop;
        private Stopwatch timer;
        private ManualResetEvent rst;
        private bool isPaused;

        #endregion

        #region Threads functions

        private void Process()
        {
            this.pop = new Population(txtPhrase.Text, Decimal.ToInt32(numPopSize.Value), Decimal.ToInt32(numMutRate.Value), rnd);
            double stopRatio=Decimal.ToDouble(this.numStopRatio.Value);


            while (!pop.isFinished)
            {
                this.pop.naturalSelection();
                this.pop.generate(this.rnd);
                this.pop.calcFitness();


                Phrase s = this.pop.bestPhrase(stopRatio);
                int num = this.pop.getGenerations;
                lock (this)
                {
                    this.lblGenNumber.Text = "Generation number: " + num.ToString();
                    this.lblTime.Text = "Execution time: " + this.timer.Elapsed.TotalSeconds + " s";
                    this.lblBestPhrase.Text = s.getPhrase();
                    stopRatio = Decimal.ToDouble(this.numStopRatio.Value);

                    this.lbxGenPhrases.Items.Add(num + ". generation:\t"+s.getPhrase() + "\tFitness:\t("+s.getFitness.ToString("0.0000")+")");


                }
                this.rst.WaitOne();
            }
            lock (this)
            {
                this.isFinished = true;
                this.lblStatus.Text = "Status: Finished";
                this.isRunning = false;
            }
        }

        private void Start()
        {
            if (this.isRunning)
            {
                return;
            }

            if (this.isPaused||this.isFinished)
            {
                this.rst.Set();
                this.timer.Reset();
                this.thread.Abort();
            }
            this.isRunning = true;

            this.thread = new Thread(Process);

            this.isCreated = true;
            this.lblStatus.Text = "Status: Running";
            this.timer.Start();
            this.thread.Start();
        }

        private void Pause()
        {
            if (this.isRunning)
            {
                this.rst.Reset();
                this.timer.Stop();
                this.isRunning = false;
                this.lblStatus.Text = "Status: Paused";
                this.isPaused = true;
            }
        }

        private void Resume()
        {
            if (!this.isRunning)
            {
                this.rst.Set();
                this.timer.Start();
                this.isRunning = true;
                this.lblStatus.Text = "Status: Running";
            }
        }

        private void Stop()
        {
            
            this.isRunning = false;
            this.lblStatus.Text = "Status: Stopped";

            this.rst.Set();

            this.thread.Abort();
            this.timer.Reset();
            this.lbxGenPhrases.Items.Clear();
        }

        #endregion

        #region Form functions

        public frmMain()
        {
            InitializeComponent();
            this.rnd = new Random();
            this.isRunning = false;
            this.isCreated = false;
            this.lblBestPhrase.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.lblGenNumber.Text = "Generation number: 0";
            this.lblTime.Text = "Execution time: 0.0000000 s";
            this.lblStatus.Text = "Status: Not running";
            this.rst = new ManualResetEvent(true);
            this.timer = new Stopwatch();
            this.isFinished = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.lbxGenPhrases.Items.Clear();
            this.numMutRate.Value = this.numMutRate.Minimum;
            this.numPopSize.Value = this.numPopSize.Minimum;
            this.txtPhrase.Text = String.Empty;
            this.lblBestPhrase.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.lblGenNumber.Text = "Generation number: 0";
            this.lblTime.Text = "Execution time: 0.0000000 s";
            this.lblStatus.Text = "Status: Not running";
            this.timer.Reset();
            
            if(this.isCreated)
             this.thread.Abort();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (this.isCreated)
                this.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.isCreated)
                this.Resume();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.isCreated)
                this.Stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (this.isCreated)
                this.Pause();
        }

        private void txtPhrase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        #endregion

    }
}