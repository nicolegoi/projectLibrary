using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nicolegoihman215871583.utilities
{
    public static class DisplayUtilities
    {
    public static void FillDataGrid(DataGridView gv, DataTable table)
    {
        gv.DataSource = table.DefaultView;

    }
    public static void DisplayListView(ListView lv, DataRow[] rows)
    {
        foreach (DataRow dr in rows)
        {
            ListViewItem it = new ListViewItem(dr[0].ToString());
            for (int i = 1; i < dr.ItemArray.Length; i++)
                it.SubItems.Add(dr[i].ToString());
            lv.Items.Add(it);
        }
    }
    public static string RecordExist(DataTable Table, string strSqrl)
    {
        string s;
        data.Class1.GetDataSet(strSqrl);
        if (data.Class1.ds.Tables[0].Rows.Count == 0)
            s = "רשומה לא קיימת";
        else
            s = "רשומה קיימת";
        return s;
    }
    public static void FillCombo(DataTable Table, int col, ComboBox cmb)// קומבו ממלא

    {
        List<string> list1 = new List<string>();
        for (int i = 0; i < Table.Rows.Count; i++)//לקומבו בטבלה מעמודה פריטים מעתיקים
        {
            cmb.Items.Add(Table.Rows[i][col].ToString());
        }
        for (int i = 0; i < cmb.Items.Count; i++)// אם רק פריט לרשימה מהקומבו פריטים מעתיקים
                                                 //אינו קיים בה
        {
            string s = cmb.Items[i].ToString();
            if (!list1.Contains(s))
                list1.Add(s);
        }
        PopulateCmbFromList(list1, cmb);
    }
    public static void PopulateList(DataTable table, List<int> myList)
    {
        foreach (DataRow row in table.Rows)
        {
            myList.Add((int)row[0]);
        }
    }
    public static void PopulateCmbFromList(List<string> list2, ComboBox cmb1)
    {
        cmb1.Items.Clear();
        for (int j = 0; j < list2.Count; j++)
            cmb1.Items.Add(list2.ElementAt(j).ToString());
    }
    public static void DisableControls(Control c)
    {
        foreach (Control Ctrl in c.Controls)
        {
            if (Ctrl is TextBox)
                Ctrl.Enabled = false;
            if (Ctrl is CheckBox)
                ((CheckBox)Ctrl).Enabled = false;
            if (Ctrl is ComboBox)
                ((ComboBox)Ctrl).Enabled = false;
            if (Ctrl is DateTimePicker)
                (Ctrl as DateTimePicker).Enabled = false;
        }
    }
    public static string GetGreetingText()
    {
        int hour = DateTime.Now.Hour;
        string greeting = "";
        if (hour >= 5 && hour < 12)
        {
            greeting = "בוקר טוב";
        }
        else if (hour >= 12 && hour < 18)
        {
            greeting = "צהריים טובים";
        }
        else if (hour >= 18 && hour < 21)
        {
            greeting = "ערב טוב";
        }
        else if (hour >= 21 || hour < 5)
        {
            greeting = "לילה טוב";
        }
        return greeting;
    }

    /// <summary>
    /// get the hour time in [hh:mm] format
    /// </summary>
    /// <returns>string</returns>
    public static string GetHourString()
    {
        string hour = DateTime.Now.Hour.ToString();
        string min = DateTime.Now.Minute.ToString();
        if (hour.Length < 2) hour = $"0{hour}";
        if (min.Length < 2) min = $"0{min}";
        return $"{hour}:{min}";
    }
    public static void EnableControls(Control c)
    {
        foreach (Control Ctrl in c.Controls)
        {
            if (Ctrl is TextBox)
                Ctrl.Enabled = true;
            if (Ctrl is CheckBox)
                ((CheckBox)Ctrl).Enabled = true;
            if (Ctrl is ComboBox)
                ((ComboBox)Ctrl).Enabled = true;
            if (Ctrl is DateTimePicker)
                (Ctrl as DateTimePicker).Enabled = true;
        }
    }
    public static void ClearControls(Control c)
    {
        foreach (Control Ctrl in c.Controls)
        {
            switch (Ctrl.GetType().ToString())
            {
                case "System.Windows.Forms.CheckBox":
                    ((CheckBox)Ctrl).Checked = false;
                    break;
                case "System.Windows.Forms.TextBox":
                    ((TextBox)Ctrl).Text = "";
                    break;
                case "System.Windows.Forms.DateTimePicker":
                    ((DateTimePicker)Ctrl).Value = DateTime.Now;
                    break;
                case "System.Windows.Forms.ComboBox":
                    ((ComboBox)Ctrl).Text = " ";
                    break;

            }
        }
    }
    public static void FillComboWithCondition(DataTable Table, int col, string conditionS, ComboBox cmb)
    {
        for (int i = 0; i < Table.Rows.Count; i++)// תנאי עם בטבלה מעמודה פריטים מעתיקים
            if (Table.Rows[i][col].ToString().Equals(conditionS))
                cmb.Items.Add(Table.Rows[i][col].ToString());
    }
    public static bool ContIsfull(Control c)
    {
        bool f = true;
        foreach (Control Ctrl in c.Controls)
        {
            if (Ctrl is TextBox)
            {
                if (Ctrl.Text == " ")
                    f = false;
            }
            if (Ctrl is ComboBox)
            {
                if (Ctrl.Text == " ")
                    f = false;
            }
        }
        return f;
    }
}
}

