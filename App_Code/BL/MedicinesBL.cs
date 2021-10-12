using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;


public static class MedicinesBL
{
	public static DataTable SortMedicines(ArrayList IdArray , DataTable AllMedicines)
    {
        int i=0;
        DataTable SortedMedicines = MedicinesDAL.GetEmptyTable();
        SortedMedicines.Columns.Add();
        SortedMedicines.Columns[7].ColumnName = "TotalPrice";
        SortedMedicines.Columns["TotalPrice"].DataType = typeof(int);
        SortedMedicines.Columns.Add();
        SortedMedicines.Columns[8].ColumnName = "Count";
        SortedMedicines.Columns["Count"].DataType = typeof(int);
        foreach (object o in IdArray)
        {
            foreach (DataRow dr in AllMedicines.Rows)
            {
                if (o.ToString() == dr["MedicineId"].ToString())
                {
                    SortedMedicines.Rows.Add();
                    SortedMedicines.Rows[i]["MedicineId"] = dr["MedicineId"];
                    SortedMedicines.Rows[i]["MedicineName"] = dr["MedicineName"];
                    SortedMedicines.Rows[i]["Category"] = dr["Category"];
                    SortedMedicines.Rows[i]["Discription"] = dr["Discription"];
                    SortedMedicines.Rows[i]["Stock"] = dr["Stock"];
                    SortedMedicines.Rows[i]["Price"] = dr["Price"];
                    SortedMedicines.Rows[i]["Image"] = dr["Image"];
                    SortedMedicines.Rows[i]["TotalPrice"] = dr["Price"];
                    SortedMedicines.Rows[i]["Count"] = 1;
                    i++;
                }
            }
        }
        return SortedMedicines;
    }
    public static DataTable AddMedicinesToSortMedicines(ArrayList IdArray, DataTable AllMedicines,
        DataTable MedicinesOrdered)
    {
        int i = 0;
        DataTable NewTableSortedMedicines = MedicinesDAL.GetEmptyTable();
        NewTableSortedMedicines = SortMedicines(IdArray, AllMedicines);
        foreach (DataRow dr in MedicinesOrdered.Rows)
        {
            NewTableSortedMedicines.Rows[i]["TotalPrice"] = dr["TotalPrice"];
            NewTableSortedMedicines.Rows[i]["Count"] = dr["Count"];
            i++;
        }
        return NewTableSortedMedicines;
    }
    public static DataTable TotalPriceForEachMedicine(DataTable MedicinesOrderd)
    {
        foreach (DataRow dr in MedicinesOrderd.Rows)
        {
            dr["TotalPrice"] = int.Parse (dr["Count"].ToString()) * int.Parse(dr["Price"].ToString ());
        }
        return MedicinesOrderd;
    }
    public static int TotalPriceOfMedicinesOrdered(DataTable MedicinesOrderd)
    {
        int TotalPrice = 0;
        foreach (DataRow dr in MedicinesOrderd.Rows)
        {
            dr["TotalPrice"] = int.Parse(dr["Count"].ToString()) * int.Parse(dr["Price"].ToString());
            TotalPrice += int.Parse (dr["TotalPrice"].ToString());
        }
        return TotalPrice;
    }
    public static ArrayList DeleteMedicineIdFromArray(int MedicineId, ArrayList MedicinesId)
    {
        for(int i = 0 ;i<MedicinesId.Count; i++ )
        {
            if (MedicineId == int.Parse(MedicinesId[i].ToString()))
            {
                MedicinesId.RemoveAt(i);
                break;
            }
        }
        return MedicinesId;
            
    }
}
