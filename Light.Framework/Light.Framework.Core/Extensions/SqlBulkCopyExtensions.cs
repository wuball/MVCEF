﻿using System.Data;
using System.Data.SqlClient;

namespace Light.Framework.Core.Extensions
{
    public static class SqlBulkCopyExtensions
    {
        public static void MapColumns(this SqlBulkCopy bulk, DataTable table)
        {
            foreach (DataColumn column in table.Columns)
            {
                bulk.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }
        }
    }
}
