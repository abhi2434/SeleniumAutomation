using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.Mobile.Common;
using Automation.Mobile.PageModels;

namespace Automation.Mobile
{
    [TestClass]
    public class IdeaTest : MobileBase
    {
        private LoginPage loginModel = null;
        private IdeasModel ideasModel = null;
        [TestCategory("Mobile")]
        [TestMethod]
        public void Idea_Creation_Save()
        {
            loginModel = new LoginPage(this.CurrentDriver, this.CurrentTest);
            var models = this.GetCurrentData();
            if (models.Count > 0)
            {
                var firstRow = models[0];
                loginModel.ActivateLogin(firstRow.P1, firstRow.P2, firstRow.P3, firstRow.P4);
                ideasModel = new IdeasModel(this.CurrentDriver, this.CurrentTest);
                ideasModel.ClickAdd();

                ideasModel.AddDetailsForFrame(firstRow.P5, firstRow.P6, firstRow.P7,
                    firstRow.P8, firstRow.P9, firstRow.P10, firstRow.P11);

                loginModel.Logout();

                loginModel.ActivateLogin(firstRow.P12, firstRow.P13, firstRow.P14, firstRow.P15);
                //ideasModel = new IdeasModel(this.CurrentDriver, this.CurrentTest);

                ideasModel.SelectApprovals();
                ideasModel.SelectFirstItem();

                ideasModel.PublishIdea(firstRow.P16);

                loginModel.Logout();
                loginModel.ActivateLogin(firstRow.P17, firstRow.P18, firstRow.P19, firstRow.P20);

                ideasModel.SetRole("Level 1 Approval");
                ideasModel.SelectFirstItem();

                ideasModel.L1Approve(firstRow.P21);
                loginModel.Logout();
                loginModel.ActivateLogin(firstRow.P22, firstRow.P23, firstRow.P24, firstRow.P25);

                ideasModel.SetRole("Level 2 Approval");
                ideasModel.SelectFirstItem();
                ideasModel.L2Approve(firstRow.P26);
                loginModel.Logout();
            }
        }
    }
}
