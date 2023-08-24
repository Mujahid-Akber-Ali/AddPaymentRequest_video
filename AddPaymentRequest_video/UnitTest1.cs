using AventStack.ExtentReports;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging.Console.Internal;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace AddPaymentRequest_video
{
    public class UnitTest1 : PageTest
    {

        [SetUp]
        public async Task setup()
        {
            ContextOptions();

            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            ExtentReport.LogReport("AddPaymentRequest_Test");

        }

        [TearDown]
        public async Task teardown()
        {
            Thread.Sleep(3000);
            // Stop tracing and export it into a zip archive.
            await Context.Tracing.StopAsync(new()
            {
                Path = @"trace/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString() + ".zip"
            });

            ExtentReport.extentReports.Flush();

            await Context.CloseAsync();
            await Browser.CloseAsync();


            //  driver.Close();
        }
        [Test]
        public async Task Test1()
        {
            ExtentReport.exParentTest = ExtentReport.extentReports.CreateTest("AddPaymentRequest_Test");

            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Admin Login To Select Manual");

            await Page.GotoAsync("http://localhost:8083/uind/");

            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "Admin", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");


            //going to payment request
            //Direct sends to Accounts
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(8) > a", "Click Admin");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li:nth-child(1) > a", "Click Setup");
            await Click("body > div.container-fluid > main > div > div:nth-child(5) > div > div:nth-child(4) > div > ul > li:nth-child(1) > a", "Click Payment Request type");

            //Searching death insurance
            await Write("#DataTables_Table_0_filter > label > input", "death", "Search death insurance");
            await Click("#DataTables_Table_0 > tbody > tr > td:nth-child(6) > a", "Click Edit");

            //Select payment request type
            await Click("#isOpened1", "Click manual creation");
            await Click("#paymentRequestTypeApp > button", "Press Submit");

            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");





            // Login to add pay request
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login to add pay request");
            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "mustafa.khan", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");

            //going to payment request
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(3) > a", "Click Account & Finance");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li > a", "Click Payment Request");
            await Click("body > div.container-fluid > main > div > div.mb-4.d-flex.justify-content-between > div > a", "Click Add Request");

            await Page.Locator("#payToType").SelectOptionAsync("Employee");

            await Press("#paymentRequestApp > form > div:nth-child(4) > div > div.col-sm-9 > div:nth-child(2) > div:nth-child(2) > div > input.form-control.is-invalid", "A");
            await Click("#paymentRequestApp > form > div:nth-child(4) > div > div.col-sm-9 > div:nth-child(2) > div:nth-child(2) > div > div > a:nth-child(5)", "Click Supplier");

            await Page.Locator("#type").SelectOptionAsync("DEATH_INSURANCE");

            await Press("#totalAmount", "Backspace");
            await Write("#totalAmount", "12", "Add Amount");


            await Write("#dueDate", "2023-08-14", "Enter Date");
            await Write("#notes", "This is 100% Okay", "Add Notes");

            await Click("#paymentRequestApp > form > button", "Click Forward for Approval");

            await Click("#DataTables_Table_0_filter > label > input", "Check Status");


            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");




            //Admin Login for Depatment Approval
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Admin Login for Depatment Approval");
            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "Admin", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");


            //going to payment request
            //Direct sends to Accounts
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(8) > a", "Click Admin");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li:nth-child(1) > a", "Click Setup");
            await Click("body > div.container-fluid > main > div > div:nth-child(5) > div > div:nth-child(4) > div > ul > li:nth-child(1) > a", "Click Payment Request type");

            //Searching death insurance
            await Write("#DataTables_Table_0_filter > label > input", "death", "Search death insurance");
            await Click("#DataTables_Table_0 > tbody > tr > td:nth-child(6) > a", "Click Edit");

            //Select payment request type
            await Click("#isDepartmentApprovalRequired1", "Click Department Approval");
            await Click("#paymentRequestTypeApp > button", "Press Submit");

            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");






            // Login to add pay request
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login to add pay request");
            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "mustafa.khan", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");

            //going to payment request
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(3) > a", "Click Account & Finance");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li > a", "Click Payment Request");
            await Click("body > div.container-fluid > main > div > div.mb-4.d-flex.justify-content-between > div > a", "Click Add Request");


            //Select payment request type

            await Page.Locator("#payToType").SelectOptionAsync("Employee");

            await Press("#paymentRequestApp > form > div:nth-child(4) > div > div.col-sm-9 > div:nth-child(2) > div:nth-child(2) > div > input.form-control.is-invalid", "S");
            await Click("#paymentRequestApp > form > div:nth-child(4) > div > div.col-sm-9 > div:nth-child(2) > div:nth-child(2) > div > div > a:nth-child(5)", "Click Supplier");

            await Page.Locator("#type").SelectOptionAsync("DEATH_INSURANCE");

            await Press("#totalAmount", "Backspace");
            await Write("#totalAmount", "12", "Add Amount");


            await Write("#dueDate", "2023-08-17", "Enter Date");
            await Write("#notes", "This is 100% Okay", "Add Notes");

            await Click("#paymentRequestApp > form > button", "Click Forward for Approval");

            await Click("#DataTables_Table_0_filter > label > input", "Check Status");


            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");





            //Admin Login for Division Approval
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Admin Login for Division Approval");

            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "Admin", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");


            //going to payment request
            //Direct sends to Accounts
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(8) > a", "Click Admin");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li:nth-child(1) > a", "Click Setup");
            await Click("body > div.container-fluid > main > div > div:nth-child(5) > div > div:nth-child(4) > div > ul > li:nth-child(1) > a", "Click Payment Request type");

            //Searching death insurance
            await Write("#DataTables_Table_0_filter > label > input", "death", "Search death insurance");
            await Click("#DataTables_Table_0 > tbody > tr > td:nth-child(6) > a", "Click Edit");

            //Select payment request type
            await Click("#isFunctionApprovalRequired1", "Click Division Approval");
            await Click("#paymentRequestTypeApp > button", "Press Submit");

            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");





            // Login to add pay request
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login to add pay request");
            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "mustafa.khan", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");

            //going to payment request
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(3) > a", "Click Account & Finance");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li > a", "Click Payment Request");
            await Click("body > div.container-fluid > main > div > div.mb-4.d-flex.justify-content-between > div > a", "Click Add Request");


            //Select payment request type

            await Page.Locator("#payToType").SelectOptionAsync("Employee");

            await Press("#paymentRequestApp > form > div:nth-child(4) > div > div.col-sm-9 > div:nth-child(2) > div:nth-child(2) > div > input.form-control.is-invalid", "D");
            await Click("#paymentRequestApp > form > div:nth-child(4) > div > div.col-sm-9 > div:nth-child(2) > div:nth-child(2) > div > div > a:nth-child(5)", "Click Supplier");

            await Page.Locator("#type").SelectOptionAsync("DEATH_INSURANCE");

            await Press("#totalAmount", "Backspace");
            await Write("#totalAmount", "12", "Add Amount");


            await Write("#dueDate", "2023-09-17", "Enter Date");
            await Write("#notes", "This is 100% Okay", "Add Notes");

            await Click("#paymentRequestApp > form > button", "Click Forward for Approval");

            await Click("#DataTables_Table_0_filter > label > input", "Check Status");


            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");








            //Admin Login for Authority Approval
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Admin Login for Authority Approval");

            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "Admin", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");


            //going to payment request
            //Direct sends to Accounts
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(8) > a", "Click Admin");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li:nth-child(1) > a", "Click Setup");
            await Click("body > div.container-fluid > main > div > div:nth-child(5) > div > div:nth-child(4) > div > ul > li:nth-child(1) > a", "Click Payment Request type");

            //Searching death insurance
            await Write("#DataTables_Table_0_filter > label > input", "death", "Search death insurance");
            await Click("#DataTables_Table_0 > tbody > tr > td:nth-child(6) > a", "Click Edit");

            //Select payment request type
            await Click("xpath=//html/body/div[1]/main/div/form/div[2]/div/div/div[1]/div[4]/div/input", "Click Authentification Approval");
            await Click("#paymentRequestTypeApp > button", "Press Submit");

            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");


            // Login to add pay request
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login to add pay request");
            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "mustafa.khan", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");

            //going to payment request
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(3) > a", "Click Account & Finance");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li > a", "Click Payment Request");
            await Click("body > div.container-fluid > main > div > div.mb-4.d-flex.justify-content-between > div > a", "Click Add Request");


            //Select payment request type

            await Page.Locator("#payToType").SelectOptionAsync("Employee");

            await Press("#paymentRequestApp > form > div:nth-child(4) > div > div.col-sm-9 > div:nth-child(2) > div:nth-child(2) > div > input.form-control.is-invalid", "G");
            await Click("#paymentRequestApp > form > div:nth-child(4) > div > div.col-sm-9 > div:nth-child(2) > div:nth-child(2) > div > div > a:nth-child(5)", "Click Supplier");

            await Page.Locator("#type").SelectOptionAsync("DEATH_INSURANCE");

            await Press("#totalAmount", "Backspace");
            await Write("#totalAmount", "12", "Add Amount");


            await Write("#dueDate", "2023-09-23", "Enter Date");
            await Write("#notes", "This is 100% Okay", "Add Notes");

            await Click("#paymentRequestApp > form > button", "Click Forward for Approval");

            await Click("#DataTables_Table_0_filter > label > input", "Check Status");


            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");



            // Login to add pay request
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Department Approval");
            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "danish.uddin", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");

            //going to payment request
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(3) > a", "Click Account & Finance");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li:nth-child(1) > a", "Click Payment Request");
            await Click("body > div.container-fluid > header > div > ul > li:nth-child(2) > a", "Click Department Approval");

            await Click("xpath=//html/body/div[1]/main/div/form/div[1]/div[2]/div/table/tbody/tr[1]/td[1]/div/input", "Click First Payto");
            await Click("xpath=//html/body/div[1]/main/div/form/div[1]/div[2]/div/table/tbody/tr[2]/td[1]/div/input", "Click Second Payto");
            await Click("xpath=//html/body/div[1]/main/div/form/div[1]/div[2]/div/table/tbody/tr[3]/td[1]/div/input", "Click Third Payto");


            await Click("body > div.container-fluid > main > div > form > div.d-flex.justify-content-end > button", "Click Approve Selected");




            // Division Approval
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Division Approval");
            await Click("body > div.container-fluid > header > div > ul > li:nth-child(3) > a", "Click Divison Approval");
            await Click("xpath=//html/body/div[1]/main/div/form/div[1]/div[2]/div/table/tbody/tr[1]/td[1]/div/input", "Click Payto");
            await Click("body > div.container-fluid > main > div > form > div.d-flex.justify-content-end > button", "Click Approve Selected");


            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");






            // Login by Adnan.khan Authority Approval
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Authority Approval");
            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "adnan.khan", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");

            //going to payment request
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(3) > a", "Click Account & Finance");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li > a", "Click Payment Request");
            await Click("body > div.container-fluid > header > div > ul > li:nth-child(4) > a", "Click Authority Approval");

            await Click("xpath=//html/body/div[1]/main/div/form/div[1]/div[2]/div/table/tbody/tr[1]/td[1]/div/input", "Click Payto");
            await Click("body > div.container-fluid > main > div > form > div.d-flex.justify-content-end > button", "Click Apporval");


            //logout
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > a", "Press account button");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-expand-lg.navbar-dark.bg-dark > div > div > form > button", "Clicking Logout");


            // Login to add pay request
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login to check Status");
            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "mustafa.khan", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");

            //going to payment request
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(3) > a", "Click Account & Finance");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li > a", "Click Payment Request");



        }


        [Test]
        public async Task Test_Alert()
        {

            ExtentReport.exParentTest = ExtentReport.extentReports.CreateTest("AddPaymentRequest_Test");

            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Admin Login To Select Manual");

            await Page.GotoAsync("http://localhost:8083/uind/");

            await Write("body > div > div > div > div > form > div:nth-child(4) > input", "asghar.ali", "Enter Username");
            await Write("body > div > div > div > div > form > div:nth-child(5) > div > input", "Utopia01", "Enter Password");

            //Press login button
            await Click("body > div > div > div > div > form > button", "Clicking Submit");


            //going to payment request
            //Direct sends to Accounts
            await Click("body > div.container-fluid > header > div > nav > ul > li:nth-child(1) > a", "Click HRMS");
            await Click("body > div.container-fluid > header > div > nav.navbar.navbar-light.bg-light.navbar-expand-lg > ul > li:nth-child(7)", "Click Loan");
            await Click("body > div.container-fluid > main > div > div.mb-4.d-flex.justify-content-between > a", "Click New Loan Request");

            await Write("body > div.container-fluid > main > div > form > div:nth-child(2) > div > div:nth-child(1) > div.input-group > input.form-control.form-control-sm.no-arrows", "6004", "Enter Employee ID");
            await Popup("body > div.container-fluid > main > div > form > div:nth-child(2) > div > div:nth-child(1) > div.input-group > div > button", "Accept");

            await Write("body > div.container-fluid > main > div > form > div:nth-child(3) > div > div:nth-child(1) > div.input-group > input", "75000", "Enter Amount");
            await Popup("body > div.container-fluid > main > div > form > div:nth-child(3) > div > div:nth-child(1) > div.input-group > div > button", "Accept");

            await Write("body > div.container-fluid > main > div > form > div:nth-child(4) > div:nth-child(2) > div:nth-child(1) > div.input-group > input.form-control.form-control-sm.no-arrows", "6002", "Enter Gaurantee ID");
            await Popup("body > div.container-fluid > main > div > form > div:nth-child(4) > div:nth-child(2) > div:nth-child(1) > div.input-group > div > button", "Accept");

            //await Click("body > div > div > div > div > form > button", "Clicking Return");

        }

        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                RecordVideoDir = @"videos/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString(),
                //StorageStatePath = @"state\pagetest_state.json",
                ViewportSize = new ViewportSize
                {
                    Height = 780,
                    Width = 1380
                },
                RecordVideoSize = new RecordVideoSize
                {
                    Height = 780,
                    Width = 1380
                }
            };

        }


        public async Task Write(string locator, string data, string detail)
        {
            try
            {
                await Page.FillAsync(locator, data);
                await ExtentReport.TakeScreenshot(Page, Status.Pass, detail);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                await ExtentReport.TakeScreenshot(Page, Status.Fail, "Entry Failed" + ex);
            }
        }

        public async Task Click(string locator, string detail)
        {
            try
            {
                await Page.ClickAsync(locator);
                await ExtentReport.TakeScreenshot(Page, Status.Pass, detail);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                await ExtentReport.TakeScreenshot(Page, Status.Fail, "Click Failed" + ex);
            }
        }

        public async Task Press(string locator, string key)
        {
            try
            {
                await Page.PressAsync(locator, key);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                await ExtentReport.TakeScreenshot(Page, Status.Fail, "Click Failed" + ex);
            }
        }

        public async Task Popup(string locator, string dec)
        {
            var dialogTaskCompletionSource = new TaskCompletionSource<IDialog>();

            // Event listener to capture dialog creation
            Page.Dialog += (_, dialog) =>
            {
                dialogTaskCompletionSource.TrySetResult(dialog);
            };

            // Click on something that might trigger a dialog
            await Page.ClickAsync(locator);

            // Wait for the dialog to be created
            var dialog = await dialogTaskCompletionSource.Task;

            try
            {
                if (dec == "Accept")
                {
                    await dialog.AcceptAsync();
                }
                else
                {
                    await dialog.DismissAsync();
                }


                await Page.WaitForTimeoutAsync(3000);

         
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while handling the dialog: {ex.Message}");
                // Handle the exception gracefully if needed
            }

        }
    }
}