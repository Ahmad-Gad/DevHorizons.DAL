// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="GlobalSuppressions.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//     This file is used by Code Analysis to maintain SuppressMessage attributes that are applied to this project.
//     Project-level suppressions either have no target or are given a specific target and scoped to a namespace, type, member, etc.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "It is designed to return the default value if failed.", Scope = "type", Target = "~T:DevHorizons.DAL.ExtensionMethods")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Needs to be consumed and reassigned by the derived class.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.AParameter")]
[assembly: SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "The command will not be passed by user. The command type is set to 'StoredProcedure' and the command text will be always hard coded stored procedure.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.ACommand")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "The exception DbException is already handled, but avoiding any risk for different exception to be raised without handling.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.ACommand")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "This is hard coded custom error messages as designed.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.ACommand")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "It will be consumed by the drived classes.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.ACommand")]
[assembly: SuppressMessage("Style", "IDE0038:Use pattern matching", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Shared.Shared.ToStructuredDbType(System.Object,DevHorizons.DAL.Interfaces.IDataAccessSettings,DevHorizons.DAL.Cache.IMemoryCache,System.Action{DevHorizons.DAL.Interfaces.ILogDetails})~System.Data.DataTable")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "The period is not prober for the current message as I need to list all the possible C# methods which could be called.", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteQuery``1(System.String,System.Collections.Generic.ICollection{DevHorizons.DAL.Interfaces.IParameter})~System.Collections.Generic.List{``0}")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteScalar``1(System.String,DevHorizons.DAL.Interfaces.IParameter[])~``0")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteScalar``1(System.String,System.Collections.Generic.ICollection{DevHorizons.DAL.Interfaces.IParameter})~``0")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteScalar(System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}})~System.Object")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteScalar(System.String,DevHorizons.DAL.Interfaces.IParameter[])~System.Object")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteScalar(System.String,System.Collections.Generic.ICollection{DevHorizons.DAL.Interfaces.IParameter})~System.Object")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteQuery``1(System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}})~System.Collections.Generic.List{``0}")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteQuery``1(System.String,DevHorizons.DAL.Interfaces.IParameter[])~System.Collections.Generic.List{``0}")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteScalar``1(System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}})~``0")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.ExecuteCommand(System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}})~System.Boolean")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "<Pending>", Scope = "member", Target = "~M:DevHorizons.DAL.Interfaces.ICommand.AddParameters(DevHorizons.DAL.Interfaces.IParameter[])")]
