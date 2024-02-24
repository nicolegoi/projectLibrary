using nicolegoihman215871583.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace nicolegoihman215871583.utilities
{
    class GeneralUtilities
    {
        protected DataTable table;
        protected int currentRow;
        protected string primaryKey;
        public static int GoToFirst(DataTable table, int currentRow)
        {
            if (IsEmpty(table))
                throw new Exception("ניווט על טבלה ריקה");
            return currentRow = 0;
        }
        // מעדכן את השורה הנוכחית לשורה האחרונה 
        public static int GoToLast(DataTable table, int currentRow)
        {
            if (IsEmpty(table))
                throw new Exception("ניווט על טבלה ריקה");
            return currentRow = table.Rows.Count - 1;
        }
        ///  עובר לשורה הבאה בטבלה.אם אנחנו בסוף חוזרים להתחלה 
        public static int MoveNext(DataTable table, int currentRow)
        {
            if (IsEmpty(table))
                throw new Exception("ניווט על טבלה ריקה");
            return currentRow = (currentRow + 1) % table.Rows.Count;
        }
        /// moves to the previous object. If reaches the beginning, goes back
        /// to the end
        public static int MovePrev(DataTable table, int currentRow)
        {
            if (IsEmpty(table))
                throw new Exception("ניווט על טבלה ריקה");
            if (currentRow == 0)
                currentRow = currentRow + 1;
            else
                --currentRow;
            return currentRow;
        }
        public static int Size(DataTable table)
        {
            return table.Rows.Count;
        }

        public static bool IsEmpty(DataTable table)
        {
            return (table.Rows.Count == 0);

        }
        public static string AddRecd(DataTable table, string strSqrl)// רשומה הוספת
        {
            Class1.GetDataSet(strSqrl);
            string st = "נתונים נשמרו";
            return st;
        }
        public static void RefreshTable(DataTable table, string tableName)
        {
            Class1.GetDataSet("Select * from " + tableName);
            table = Class1.ds.Tables[0];
        }


        public static string UpDateRecd(DataTable table, string strSqrl)//רשומה עידכון
        {
            Class1.GetDataSet(strSqrl);
            string st = "נתונים עודכנו ";
            return st;
        }
        public static string DeleteRecd(DataTable table, string strSqrl)//רשומה מחיקת
        {
            Class1.GetDataSet(strSqrl);
            string st = "נתונים נמחקו";
            return st;
        }
        public static string RecordExist(DataTable Table, string strSqrl)
        {
            string s;
            Class1.GetDataSet(strSqrl);
            if (Class1.ds.Tables[0].Rows.Count == 0)
                s = "רשומה לא קיימת";
            else
                s = "רשומה קיימת";
            return s;
        }


   
    } 
} 
