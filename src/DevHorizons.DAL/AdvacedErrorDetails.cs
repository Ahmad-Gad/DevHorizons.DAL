// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AdvacedErrorDetails.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines all the needed members for raised error/exceptions plus deep info/statistics on the current environment and the hardware resources.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>12/02/2022 04:58 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    using Interfaces;

    /// <summary>
    ///    A class defines all the needed members for raised error/exceptions plus deep info/statistics on the current environment and the hardware resources.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>12/02/2022 04:58 PM</DateTime>
    /// </Created>
    public class AdvacedErrorDetails : ErrorDetails
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="AdvacedErrorDetails"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:34 PM</DateTime>
        /// </Created>
        public AdvacedErrorDetails() : base()
        {
            this.PopulateValues();
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="AdvacedErrorDetails"/> class from an instance of the base class "<see cref="ErrorDetails"/>".
        /// </summary>
        /// <param name="errorDetails">An instance of the base class "<see cref="ErrorDetails"/>".</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:34 PM</DateTime>
        /// </Created>
        public AdvacedErrorDetails(ILogDetails errorDetails) : this()
        {
            var props = errorDetails.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            this.MapValues(errorDetails, props.ToList());
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the <c>CPU</c> usage percent (<c>%</c>) of the current associated process.
        /// </summary>
        /// <value>
        ///    The <c>CPU</c> usage percent (<c>%</c>) of the current associated process.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public double CpuUsagePercent { get; set; }

#if NET48 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0
        /// <summary>
        ///    Gets or sets the total memory allocated to the current thread since the beginning of its lifetime as number of bytes.
        /// </summary>
        /// <value>
        ///    The total bytes of memeory allocated to the current thread since the beginning of its lifetime.
        /// </value>
        /// <remarks>This value is provided by the <c>OOTB</c> "<see cref="GC"/>" by the host "<c>CLR</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public long CurrentThreadAllocatedMemory { get; set; } = GC.GetAllocatedBytesForCurrentThread();
#endif

#if NETCOREAPP3_1 || NET5_0 || NET6_0
        /// <summary>
        ///    Gets or sets the total memory allocated to the current process of the running/host service/application since the beginning of its lifetime as number of bytes.
        /// </summary>
        /// <value>
        ///    The total bytes of memeory allocated to the current process since the beginning of its lifetime.
        /// </value>
        /// <remarks>This value is provided by the <c>OOTB</c> "<see cref="GC"/>" by the host "<c>CLR</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public long CurrentProcessAllocatedMemory { get; set; } = GC.GetTotalAllocatedBytes();
#endif

        /// <summary>
        ///    Gets or sets the total installed/acllocated logical processors (<c>CPUs</c>).
        /// </summary>
        /// <value>
        ///    The total installed/acllocated logical processors (<c>CPUs</c>).
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public int ProcessorCount { get; set; } = Environment.ProcessorCount;

        /// <summary>
        ///    Gets or sets the current command line of the current running process.
        /// </summary>
        /// <value>
        ///    The command line for this process.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public string CommandLine { get; set; } = Environment.CommandLine;

#if NET6_0
        /// <summary>
        ///    Gets or sets the path of the executable that started the currently executing process.
        /// </summary>
        /// <value>
        ///    The path of the executable that started the currently executing process.
        ///    <para>Returns null when the path is not available.</para>
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public string ProcessPath { get; set; } = Environment.ProcessPath;
#endif

#if NET5_0 || NET6_0
        /// <summary>
        ///    Gets or sets the unique identifier for the current process.
        /// </summary>
        /// <value>
        ///    An integer number that represents the unique identifier for the current process.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public int ProcessId { get; set; } = Environment.ProcessId;

        /// <summary>
        ///    Gets or sets the platform on which an app is running.
        /// </summary>
        /// <value>
        ///    An opaque string that identifies the platform on which the app is running.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public string Platform { get; set; } = RuntimeInformation.RuntimeIdentifier;
#endif

        /// <summary>
        ///    Gets or sets the current operating system version's details including type, edition, version, platform architecture, etc.
        /// </summary>
        /// <value>
        ///    The current/host <c>OS</c> version details concatenated in one line string.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public string OSVersion { get; set; } = Environment.OSVersion.VersionString;

        /// <summary>
        ///    Gets or sets a string that describes the operating system on which the app is running.
        /// </summary>
        /// <value>
        ///    The string that describes the operating system on which the app is running.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public string OSDescription { get; set; } = RuntimeInformation.OSDescription;

        /// <summary>
        ///    Gets or sets the OS architecture. E.g. <c>X64</c>, <c>X86</c>, <c>ARM64</c>, etc.
        /// </summary>
        /// <value>
        ///    The OS architecture. E.g. <c>X64</c>, <c>X86</c>, <c>ARM64</c>, etc.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public string OSArchitecture { get; set; } = RuntimeInformation.OSArchitecture.ToString();

        /// <summary>
        ///    Gets or sets the currnt <c>CLR</c> (Common Language Runtime) a version consisting of the major, minor, build, and revision numbers in one line string.
        /// </summary>
        /// <value>
        ///    The currnt <c>CLR</c> (Common Language Runtime) a version consisting of the major, minor, build, and revision numbers in one line string.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public string ClrVersion { get; set; } = Environment.Version.ToString();

        /// <summary>
        ///    Gets or sets the amount of physical memory mapped to the process context.
        /// </summary>
        /// <value>
        ///    An integer containing the number of bytes of physical memory mapped to the process context.
        /// </value>
        /// <remarks>This value is provided by the <c>OOTB</c> "<see cref="Environment"/>" class.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public long WorkingSet { get; set; } = Environment.WorkingSet;

        /// <summary>
        ///    Gets or sets the maximum amount of physical memory, in bytes, allocated for the associated process since it was started.
        /// </summary>
        /// <value>
        ///    The maximum amount of physical memory, in bytes, allocated for the associated process since it was started.
        /// </value>
        /// <remarks>This value is provided by the <c>OOTB</c> "<see cref="Environment"/>" class.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public long PeakWorkingSet { get; set; }

        /// <summary>
        ///    Gets or sets the total number of operating system handles the process has opened.
        /// </summary>
        /// <value>
        ///    The total number of operating system handles the process has opened.
        /// </value>
        /// <remarks>This value is provided by the <c>OOTB</c> "<see cref="Environment"/>" class.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public int HandleCount { get; set; }

        /// <summary>
        ///    Gets or sets the total number of threads that are running in the associated process.
        /// </summary>
        /// <value>
        ///    The total total number of threads that are running in the associated process.
        /// </value>
        /// <remarks>This value is provided by the <c>OOTB</c> "<see cref="Environment"/>" class.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public int ThreadsCount { get; set; }

        /// <summary>
        ///    Gets or sets the number of bytes in the operating system's memory page.
        /// </summary>
        /// <value>
        ///    An integer containing The number of bytes in the system memory page.
        /// </value>
        /// <remarks>This value is provided by the <c>OOTB</c> "<see cref="Environment"/>" class.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public int SystemPageSize { get; set; } = Environment.SystemPageSize;

#if NETCOREAPP3_1 || NET5_0 || NET6_0
        /// <summary>
        ///    Gets or sets the exact date/time when the host machine being started or rebooted.
        /// </summary>
        /// <value>
        ///    The exact date/time when the host machine being started or rebooted.
        /// </value>
        /// <remarks>This value is provided by the <c>OOTB</c> "<see cref="Environment"/>" class.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public DateTime LastRebootTime { get; set; } = DateTime.Now.AddSeconds(Environment.TickCount64 / 1000 * -1);
#endif

        /// <summary>
        ///    Gets or sets the exact date/time when the associated process was started.
        /// </summary>
        /// <value>
        ///    The exact date/time when the associated process was started.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        public DateTime ProcessStartTime { get; set; }
        #endregion Properties

        #region Private Methods

        #region Static Methods

        /// <summary>
        ///    Gets the <c>CPU</c> usage percent (<c>%</c>) of the current associated process.
        /// </summary>
        /// <param name="currenProcess">The current associated process.</param>
        /// <returns>
        ///    The <c>CPU</c> usage percent (<c>%</c>) of the current associated process.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        private static double GetCpuUsage(Process currenProcess)
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = currenProcess.TotalProcessorTime;
            Task.Delay(200).Wait();

            var endTime = DateTime.UtcNow;
            var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
            return Math.Round(cpuUsageTotal * 100, 1);
        }
        #endregion Static Methods

        /// <summary>
        ///    Populate the properties with the required values in a safe manner with exception handling scope.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        private void PopulateValues()
        {
            try
            {
                var currentProcess = Process.GetCurrentProcess();
                currentProcess.Refresh();
                this.PeakWorkingSet = currentProcess.PeakWorkingSet64;
                this.HandleCount = currentProcess.HandleCount;
                this.ThreadsCount = currentProcess.Threads.Count;
                this.ProcessStartTime = currentProcess.StartTime;
                this.CpuUsagePercent = GetCpuUsage(currentProcess);
            }
            catch
            {
            }
        }

        /// <summary>
        ///    Map the properties values from the specified instance of the "<see cref="ErrorDetails"/>".
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 09:33 PM</DateTime>
        /// </Created>
        private void MapValues(ILogDetails errorDetails, List<PropertyInfo> properties)
        {
            foreach (var prop in properties)
            {
                var value = prop.GetValue(errorDetails);
                prop.SetValue(this, value);
            }
        }
        #endregion Private Methods
    }
}
