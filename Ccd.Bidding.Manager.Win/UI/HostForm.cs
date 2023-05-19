using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI
{
    public partial class HostForm : Form, IHostForm
    {
        public HeaderWidthManager HeaderWidthManager { get; private set; } = new HeaderWidthManager();

        private Stack<HostScreen> nestedScreens = new Stack<HostScreen>();

        private readonly FirstHostScreenResolver _firstScreenResolver = new FirstHostScreenResolver();


        public HostForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.onLoad);
        }

        private void onLoad(object sender, EventArgs e)
        {
            SuspendLayout();
            startFirstScreen();
            ResumeLayout();
        }
        private void startFirstScreen()
        {
            HostScreen firstScreen = _firstScreenResolver.Resolve(this);

            GoForward(firstScreen);
        }


        public void GoBack()
        {
            if (isSingleNestedScreen())
            {
                startFirstScreen();
                return;
            }

            Controls.Remove(nestedScreens.Pop());
            Controls.Add(getTopMostScreen);
            getTopMostScreen.Refresh();
            setTitleText();
        }

        private bool isSingleNestedScreen()
            => nestedScreens.Count == 1;

        public void GoForward(HostScreen control)
        {
            SuspendLayout();
            control.Visible = false;
            if (nestedScreens.Count > 0)
            {
                Controls.Remove(getTopMostScreen);
            }

            addScreenToStack(control);
            setTitleText();
        }


        public void GoTo(HostScreen control)
        {
            while (nestedScreens.Count > 0)
            {
                Controls.Remove(nestedScreens.Pop());
            }

            addScreenToStack(control);
        }
        private void addScreenToStack(HostScreen control)
        {
            nestedScreens.Push(control);
            Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.Visible = true;
            ResumeLayout();
            control.Focus();
        }


        private void setTitleText()
            => Text = $"{ getTopMostScreen.Text } - Ccd.Bidding.Manager";



        private HostScreen getTopMostScreen => nestedScreens.Peek();
    }
}
