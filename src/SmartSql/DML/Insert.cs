using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SmartSql.DML
{
    public class Insert : IDML
    {
        public StatementType StatementType => StatementType.Insert;
        public string Operation => "INSERT INTO";
        public string Table { get; set; }
        public string ParameterPrefix { get; set; }


        public IList<String> Columns { get; set; }
        public IList<String> Parameters { get; set; }

        
        public void Add(string column, string parameter)
        {
            Columns.Add(column);
            Parameters.Add(parameter);
        }



        public override string ToString()
        {
            var columns = String.Join(",", Columns);
            var parameters = String.Join(",",
                Parameters.Select(p => $"{ParameterPrefix}{p}").ToArray());
            return $"{Operation} {Table} ({columns}) Values ({parameters});";
        }
    }
}