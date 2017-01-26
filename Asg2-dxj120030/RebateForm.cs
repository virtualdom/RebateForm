using System;
using System.Windows.Forms;

namespace Asg2_dxj120030
{
    /*
     * RebateForm class
     * This class handles events occurring in the
     * rebate form UI.
     */
    public partial class RebateForm : Form
    {
        private Controller controller;    // a reference to a controller object to support functionality
        private bool addMode = true;      // a boolean to denote if you're adding versus editing a customer
        private bool timing = false;      // a boolean to denote if the UI is timing your start-of-input until you Save
        private DateTime start;           // time referring to when adding a new customer began
        private DateTime end;             // time referring to when a new customer was saved

        private string editingFName = ""; // when modifying an existing customer, maintaining his/her
        private string editingMInit = ""; // original first, middle, and last name information is useful
        private string editingLName = ""; // for looking him/her up later to actually save the changes

        /*
         * Constructor
         * This merely initializes the UI component and creates a controller
         * object. If an urgent error occurs while initializing, it reports
         * the error and aborts the application.
         */
        public RebateForm()
        {
            try
            {
                InitializeComponent();
                controller = new Controller();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Save file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controller = new Controller();
                if (e.Message.Contains("Urgent!")) Environment.Exit(-1);
            }
        }

        /*
         * RebateForm onLoad
         * This function occurs as the form has finished loading.
         * It sets various UI properties, including setting the 
         * maximum AND default date values as being today and 
         * filling the customer list with any preexisting customers.
         */
        private void RebateForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.dateReceived.MaxDate = DateTime.Today;
            this.dateReceived.Value = DateTime.Today;
            populateList();
            rebateList.ListViewItemSorter = new LvComparer();

            // Adjust the height of the grid that shows checks to maximize the
            // number we can show.
            int oldHeight = this.Height;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 2;
            rebateList.Height += (this.Height - oldHeight);
            this.CenterToScreen();
        }
        
        /*
         * setAddMode
         * This function is used to set
         * the addMode value and appropriately
         * clear stale variables.
         */
        private void setAddMode (bool newMode)
        {
            addMode = newMode;
            if (newMode)
            {
                editingFName = "";
                editingMInit = "";
                editingLName = "";
            }
        }

        /*
         * setTiming
         * This function is to set the
         * timing flag as well as time-tracking
         * variables
         */
        private void setTiming (bool timing)
        {
            this.timing = timing;
            if (timing)
            {
                start = DateTime.Now;
                end = new DateTime();
            }
            else end = DateTime.Now;
        }

        /*
         * populateList
         * This function fills the list of customers
         * with the entries that exist in the savefile
         */
        private void populateList()
        {
            rebateList.Items.Clear();
            ListViewItem[] li = controller.getList();
            foreach (ListViewItem l in li)
                rebateList.Items.Add(l);
        }

        /*
         * clearForm
         * resets all fields in the form
         * without saving anything
         */
        private void clearForm ()
        {
            fName.Clear();
            mInit.Clear();
            lName.Clear();
            addr1.Clear();
            addr2.Clear();
            city.Clear();
            state.Clear();
            zip.Clear();
            email.Clear();
            phone.Clear();
            rebateList.SelectedIndices.Clear();
            proofIncluded.Checked = false;
            dateReceived.Value = DateTime.Today;
            setAddMode(true);
            saveBtn.Enabled = false;
            setTiming(false);
        }

        /*
         * trimInputs
         * Call String.Trim() on all form inputs
         */
        private void trimInputs()
        {
            fName.Text = fName.Text.Trim();
            mInit.Text = mInit.Text.Trim();
            lName.Text = lName.Text.Trim();
            addr1.Text = addr1.Text.Trim();
            addr2.Text = addr2.Text.Trim();
            city.Text = city.Text.Trim();
            state.Text = state.Text.Trim();
            zip.Text = zip.Text.Trim();
            email.Text = email.Text.Trim();
            phone.Text = phone.Text.Trim();
        }

        /*
         * startTimer
         * If you're currently adding a new customer
         * and you haven't already started timing, start
         * timing. This gets called on every keystroke and
         * when clicking a form box that needs to be clicked
         * (hence the overloaded functions).
         */
        private void startTimer () { if (addMode && !timing) setTiming(true); }
        private void startTimer (object sender, KeyEventArgs e) { startTimer(); }
        private void startTimer (object sender,    EventArgs e) { startTimer(); }

        /*
         * enableSaveButton
         * This validates all input currently in the form.
         * If the input is valid, the Save button is enabled,
         * and if the input is invalid, the button is disabled.
         * This gets called on every keystroke and loss of focus
         * (hence the overloaded functions).
         */
        private void enableSaveButton()
        {
            if (controller.validateForm(fName.Text, Customer.initify(mInit.Text), lName.Text, addr1.Text, city.Text, state.Text, zip.Text, phone.Text, email.Text))
                saveBtn.Enabled = true;
            else
                saveBtn.Enabled = false;
        }
        private void enableSaveButton(object sender, EventArgs e) { trimInputs(); enableSaveButton(); }
        private void enableSaveButton(object sender, KeyEventArgs e) { enableSaveButton(); }

        /*
         * Save Button Click Handler
         * When the save button is clicked, do the following:
         * stop the timer
         * if UI is in add mode, add the new customer with the given information
         * if UI is in edit mode, modify the existing customer with the given information
         * reset the form and list and set back to add mode
         */
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                setTiming(false);
                trimInputs();
                if (addMode)  // if add mode is enabled, add a new customer with all field's (sanitized) text
                    controller.addCustomer(fName.Text, Customer.initify(mInit.Text), lName.Text, addr1.Text, 
                        addr2.Text, city.Text, state.Text, zip.Text, phone.Text, email.Text, proofIncluded.Checked,
                        dateReceived.Value, start, end);
                else         // if edit mode is enabled, modify the customer (based on their initial name) with sanitized text inputs
                    controller.modifyCustomer(editingFName, Customer.initify(editingMInit), editingLName, fName.Text,
                        Customer.initify(mInit.Text), lName.Text, addr1.Text, addr2.Text, city.Text, state.Text, zip.Text,
                        phone.Text, email.Text, proofIncluded.Checked, dateReceived.Value);

                clearForm();
                setAddMode(true);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Customer save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timing = true;
            }
            finally {
                populateList();
                saveBtn.Enabled = false;
                fName.Focus();
            }
        }

        /*
         * Delete Button Click Handler
         * If UI is in add mode, simply clear form.
         * If UI is in edit mode, delete the selected user and clear the form.
         */
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (!addMode)
            {
                controller.deleteCustomer(editingFName, Customer.initify(editingMInit), editingLName);
                populateList();
            }
            clearBtn_Click(sender, e);

        }

        /*
         * Clear Button Click Handler
         * Clears the form and resets to add mode.
         */
        private void clearBtn_Click(object sender, EventArgs e)
        {
            saveBtn.Enabled = false;
            setAddMode(true);
            clearForm();
            fName.Focus();
        }

        /*
         * Rebate List Click Handler
         * Whenever a rebate submitter is selected, update
         * all fields in the form and cache their initial
         * identification information for lookup later.
         * If the list is somehow out-of-sync with the file
         * and the customer cannot be found, a message box
         * appears to refresh the list.
         */
        private void rebateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rebateList.SelectedItems.Count == 0) return;

            setAddMode(false);
            editingFName = rebateList.SelectedItems[0].SubItems[2].Text;
            editingMInit = rebateList.SelectedItems[0].SubItems[3].Text;
            editingLName = rebateList.SelectedItems[0].SubItems[4].Text;

            Customer c = controller.getCustomer(editingFName, Customer.initify(editingMInit), editingLName);

            if (c == null)
            {
                MessageBox.Show("Unable to fetch customer. Press OK to refresh rebate list.", "Customer update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearForm();
                populateList();
                setAddMode(true);
                saveBtn.Enabled = false;
                return;
            }

            fName.Text = c.fName;
            mInit.Text = c.mInit.ToString();
            lName.Text = c.lName;
            addr1.Text = c.addr1;
            addr2.Text = c.addr2;
            city.Text = c.city;
            state.Text = c.state;
            zip.Text = c.zip;
            email.Text = c.email;
            phone.Text = c.phone;
            trimInputs();
            proofIncluded.Checked = c.proofAttached;
            dateReceived.Value = c.received;
            saveBtn.Enabled = true;
        }

        /*
         * Rebate List Column Click Handler
         * Whenever a column is clicked, sort the
         * list according to the column clicked. This
         * is accomplished using the LvComparer class,
         * provided by Prof. Cole.
         */
        private void rebateList_ColumnClick(object sender, ColumnClickEventArgs e) { rebateList.ListViewItemSorter = new LvComparer(e.Column); }
    }
}
