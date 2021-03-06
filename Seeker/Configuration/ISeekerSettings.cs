﻿namespace Seeker.Configuration
{
    /// <summary>
    /// Seeker settings.
    /// </summary>
    public interface ISeekerSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets a http api port.
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Gets or sets a path to the store.
        /// </summary>
        string Store { get; set; }

        /// <summary>
        /// Gets or sets a path to the security directory.
        /// </summary>
        string Security { get; set; }

        #endregion
    }
}
