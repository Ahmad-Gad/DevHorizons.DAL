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
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Needs to be consumed and reassigned by the derived class.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.Parameter")]
[assembly: SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "The command will not be passed by user. The command type is set to 'StoredProcedure' and the command text will be always hard coded stored procedure.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.Command")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "The exception DbException is already handled, but avoiding any risk for different exception to be raised without handling.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.Command")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "This is hard coded custom error messages as designed.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.Command")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "It will be consumed by the drived classes.", Scope = "type", Target = "~T:DevHorizons.DAL.Abstracts.Command")]
