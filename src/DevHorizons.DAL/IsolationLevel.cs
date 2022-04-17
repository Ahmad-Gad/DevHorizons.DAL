// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsolationLevel.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines all the possible isolation level within the database transacations.
//  </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    /// <summary>
    ///    Specifies the transaction locking behavior for the connection.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>12/02/2022 12:25 PM</DateTime>
    /// </Created>
    public enum IsolationLevel
    {
        /// <summary>
        ///    A different isolation level than the one specified is being used, but the level cannot be determined.
        ///    <para>An exception is thrown if this value is set.</para>
        /// </summary>
        Unspecified = System.Data.IsolationLevel.Unspecified,

        /// <summary>
        ///    The pending changes from more highly isolated transactions cannot be overwritten.
        /// </summary>
        Chaos = System.Data.IsolationLevel.Chaos,

        /// <summary>
        ///    A dirty read is possible, meaning that no shared locks are issued and no exclusive locks are honored.
        /// </summary>
        ReadUncommitted = System.Data.IsolationLevel.ReadUncommitted,

        /// <summary>
        ///    Shared locks are held while the data is being read to avoid dirty reads, but the data can be changed before the end of the transaction, resulting in non-repeatable reads or phantom data.
        /// </summary>
        ReadCommitted = System.Data.IsolationLevel.ReadCommitted,

        /// <summary>
        ///    Locks are placed on all data that is used in a query, preventing other users from updating the data. Prevents non-repeatable reads but phantom rows are still possible.
        /// </summary>
        RepeatableRead = System.Data.IsolationLevel.RepeatableRead,

        /// <summary>
        ///    A range lock is placed on the System.Data.DataSet, preventing other users from updating or inserting rows into the dataset until the transaction is complete.
        /// </summary>
        Serializable = System.Data.IsolationLevel.Serializable,

        /// <summary>
        ///    Reduces blocking by storing a version of data that one application can read while another is modifying the same data. Indicates that from one transaction you cannot see changes made in other transactions, even if you requery.
        /// </summary>
        Snapshot = System.Data.IsolationLevel.Snapshot
    }
}
