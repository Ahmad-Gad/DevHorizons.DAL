namespace DevHorizons.DAL.Sql
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using DAL.Attributes;
    using Interfaces;
    using Shared;

    public class SqlDataTable : DataTable
    {
        private protected ICommand cmd;

        #region Constructors
        public SqlDataTable()
        {
        }

        public SqlDataTable(ICommand cmd)
        {
            this.cmd = cmd;
        }
        #endregion Constrcutors

        #region Methods
        public override bool Insert(ICommand cmd = null)
        {
            if (this.cmd == null || !this.cmd.CanExecute())
            {
                // Handle Error
                return false;
            }

            throw new System.Exception();
        }

        public override bool Update(ICommand cmd = null)
        {
            if (this.cmd == null || !this.cmd.CanExecute())
            {
                // Handle Error
                return false;
            }

            throw new System.Exception();
        }

        public override bool Delete(ICommand cmd = null)
        {
            if (this.cmd == null || !this.cmd.CanExecute())
            {
                // Handle Error
                return false;
            }

            throw new System.Exception();
        }
        #endregion Methods

        private List<DataFieldAttribute> GetDataFields()
        {
            ///var dataFields = this.GetDataFieldList(this.cmd.Settings, this.cmd.DistributedCache, this.cmd.MemoryCache, this.cmd.HandleError);
            return null;
        }

        private List<DataFieldAttribute> GetDataFields(CommandAction commandAction)
        {
            var dataFields = this.GetDataFields();
            if (dataFields == null || dataFields.Count == 0)
            {
                // ToDo Handle Error
                return null;
            }

            var filteredFields = dataFields.Where(df => (df.Action & commandAction) == commandAction).ToList();
            return filteredFields;
        }

        /// <inheritdoc/>
        protected override List<IParameter> GetParmetersFromDataTable(CommandAction commandAction)
        {
            var props = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var parameters = new List<IParameter>();
            foreach (var prop in props)
            {
                var dataField = prop.GetCustomAttribute<DataFieldAttribute>(true);
                if (dataField == null)
                {
                    dataField = new DataFieldAttribute(prop)
                    {
                        Name = prop.Name
                    };
                }
                else
                {
                    if (dataField.NotMapped || (dataField.Action & commandAction) != commandAction)
                    {
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(dataField.Name))
                    {
                        dataField.Name = prop.Name;
                    }
                }

                var param = new SqlParameter()
                {
                    Name = dataField.Name,
                    Direction = dataField.InsertedOutput ? Direction.Output : Direction.Input,
                    DataField = dataField,
                    Encrypted = dataField.Encrypted,
                    Hashed = dataField.Hashed,
                    MayBeEncrypted = dataField.MayBeEncrypted,
                    EncryptionType = dataField.EncryptionType,
                };

                if (param.Direction == Direction.Input)
                {
                    var value = prop.GetValue(this);
                    if (value == null && dataField.AllowNull == false)
                    {
                        continue;
                    }

                    param.Value = prop.GetValue(this);
                }

                if (dataField.SpecialType != SpecialType.None)
                {
                    switch (dataField.SpecialType)
                    {
                        case SpecialType.Json:
                            {
                                param.DataType = SqlDbType.Json;
                                param.Size = -1;
                                break;
                            }

                        case SpecialType.Xml:
                            {
                                param.DataType = SqlDbType.Xml;
                                param.Size = -1;
                                break;
                            }

                        case SpecialType.Structured:
                            {
                                param.DataType = SqlDbType.Structured;
                                break;
                            }

                        case SpecialType.Binary:
                            {
                                param.DataType = SqlDbType.VarBinary;
                                param.Size = -1;
                                break;
                            }

                        case SpecialType.Base64:
                            {
                                param.DataType = SqlDbType.NVarChar;
                                param.Size = -1;
                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }

                var parameterAttribute = new ParameterAttribute
                {
                    Name = dataField.Name,
                    Direction = param.Direction,
                    SpecialType = dataField.SpecialType,
                    Size = param.Size,
                    Property = prop,
                };

                param.ParameterAttribute = parameterAttribute;
                parameters.Add(param);
            }

            return parameters;
        }

        protected override string GetParsedInsertCommand(List<IParameter> parameters)
        {
            if (parameters == null)
            {
                // ToDo Handle Error
                return null;
            }

            var columns = new StringBuilder();
            var inputs = new StringBuilder();
            var outputInserted = new StringBuilder();
            var outputs = new StringBuilder();
            var insertedTable = new StringBuilder();
            var identity = new StringBuilder();

            foreach (var par in parameters)
            {
                var colName = par.Name.TrimStart('@');
                if (par.Direction == Direction.Input || par.Direction == Direction.InputOutput)
                {
                    columns.Append($"{colName},");
                    inputs.Append($"{par.Name},");
                }

                if (par.Direction == Direction.Output || par.Direction == Direction.InputOutput)
                {
                    if (par.DataField.Identity)
                    {
                        identity = identity.Append($"{par.Name}=SCOPE_IDENTITY(),");
                    }
                    else
                    {
                        insertedTable.Append($"{colName} {((SqlParameter)par).DataType},");
                        outputInserted.Append($"Inserted.{colName},");
                        outputs.Append($"{par.Name}={colName},");
                    }

                }
            }

            var insertedTableString = string.Empty;
            var outputsString = string.Empty;
            var identityString = string.Empty;
            if (identity.Length != 0)
            {
                identityString = $"Select {identity.ToString().TrimEnd(',')};";
            }

            if (outputInserted.Length != 0)
            {
                insertedTableString = $"Declare @InsertedRow Table({insertedTable.ToString().TrimEnd(',')});";
                outputsString = $"Output {outputInserted.ToString().TrimEnd(',')} Into @InsertedRow";
            }

            var sqlCmdText = $"{insertedTableString} Insert Into {this.ObjectName} ({columns.ToString().TrimEnd(',')}) {outputsString} Values ({inputs.ToString().TrimEnd(',')}); Select {outputs.ToString().TrimEnd(',')} From @InsertedRow; {identityString}";
            return sqlCmdText;
        }

        protected override string GetParsedUpdateCommand(List<IParameter> parameters)
        {
            throw new NotImplementedException();
        }

        protected override string GetParsedDeleteCommand(List<IParameter> parameters)
        {
            throw new NotImplementedException();
        }

        protected override string GetParsedSelectCommand(List<IParameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
