namespace DevHorizons.DAL
{
    using System.Collections.Generic;
    using System.Reflection;
    //using System.Web.Http.Description;
    using Abstracts;
    using Attributes;
    using Interfaces;
    using Newtonsoft.Json;

    public abstract class DataTable : IDataTable
    {
        private protected Command cmd;

        #region Constructors
        public DataTable()
        {
        }

        public DataTable(Command cmd)
        {
            this.cmd = cmd;
        }
        #endregion Constrcutors

        #region Properties

        /// <inheritdoc/>
        [DataField(Identity = true, InsertedOutput = true)]
        //[ApiExplorerSettings(IgnoreApi = true)]
        [JsonIgnore]
        public long? Identity { get; set; }

        /// <inheritdoc/>
        [DataField(NotMapped = true)]
        [JsonIgnore]
        public long? RowsCount { get; set; }

        /// <inheritdoc/>
        [DataField(NotMapped = true)]
        //[ApiExplorerSettings(IgnoreApi = true)]
        [JsonIgnore]
        
        public string ObjectName { get; set; }
        #endregion Properties

        #region Methods
        public virtual bool Insert(ICommand cmd = null)
        {
            throw new System.Exception();
        }

        public virtual bool Update(ICommand cmd = null)
        {
            throw new System.Exception();
        }

        public virtual bool Delete(ICommand cmd = null)
        {
            throw new System.Exception();
        }
        #endregion Methods

        /// <inheritdoc/>
        List<IParameter> IDataTable.GetParmeters(CommandAction commandAction)
        {
            return this.GetParmetersFromDataTable(commandAction);
        }

        /// <inheritdoc/>
        string IDataTable.GetCommandText(List<IParameter> parameters, CommandAction commandAction)
        {
            var dataRowAttribute = this.GetType().GetCustomAttribute<DataRowAttribute>(true);
            if (dataRowAttribute != null && (dataRowAttribute.AllowedActions & commandAction) != commandAction)
            {
                // To Raise Error
                // To be moved to the Command class to avoid doing unnecessary work from the early beginning like getting the parameters list.
                return null;
            }

            if (string.IsNullOrWhiteSpace(this.ObjectName))
            {
                if (dataRowAttribute != null && !string.IsNullOrWhiteSpace(dataRowAttribute.Name))
                {
                    this.ObjectName = dataRowAttribute.Name;
                }
                else
                {
                    this.ObjectName = this.GetType().Name;
                }
            }

            switch (commandAction)
            {
                case CommandAction.Insert:
                    {
                        return this.GetParsedInsertCommand(parameters);
                    }

                case CommandAction.Update:
                    {
                        return this.GetParsedUpdateCommand(parameters);
                    }

                case CommandAction.Delete:
                    {
                        return this.GetParsedDeleteCommand(parameters);
                    }

                case CommandAction.Select:
                    {
                        return this.GetParsedDeleteCommand(parameters);
                    }

                default:
                    {
                        return null;
                    }
            }
        }

        /// <summary>
        ///    Extracts the list of the parameters from the specified "<c>DAL</c>" data table as type of of <see cref="IDataTable"/>.
        /// </summary>
        /// <param name="commandAction">The command action.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="IParameter"/>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:03 PM</DateTime>
        /// </Created>
        protected abstract List<IParameter> GetParmetersFromDataTable(CommandAction commandAction);


        protected abstract string GetParsedInsertCommand(List<IParameter> parameters);

        protected abstract string GetParsedUpdateCommand(List<IParameter> parameters);

        protected abstract string GetParsedDeleteCommand(List<IParameter> parameters);

        protected abstract string GetParsedSelectCommand(List<IParameter> parameters);
    }
}
