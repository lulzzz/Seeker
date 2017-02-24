﻿using System.Configuration;

namespace Seeker.Configuration
{
    /// <summary>
    /// Represents a configuration section for seeker settings.
    /// </summary>
    public class SeekerSection : ConfigurationSection
    {
        #region Properties

        /// <summary>
        /// Gets or sets a socket port.
        /// </summary>
        [ConfigurationProperty("port", DefaultValue = 11000, IsRequired = true)]
        public int Port
        {
            get
            {
                return (int)this["port"];
            }
            set
            {
                this["port"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a path to the store.
        /// </summary>
        [ConfigurationProperty("store", DefaultValue = @".\Extents")]
        public string Store
        {
            get
            {
                return (string)this["store"];
            }
            set
            {
                this["store"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a raw log format.
        /// </summary>
        [ConfigurationProperty("formatting", DefaultValue = LogFormatting.None)]
        public LogFormatting Formatting
        {
            get
            {
                return (LogFormatting)this["formatting"];
            }
            set
            {
                this["formatting"] = value;
            }
        }

        #endregion
    }
}