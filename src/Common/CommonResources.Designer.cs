﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Mobile.Server.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CommonResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Azure.Mobile.Server.Properties.CommonResources", typeof(CommonResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Argument must be greater than or equal to {0}..
        /// </summary>
        internal static string ArgMustBeGreaterThanOrEqualTo {
            get {
                return ResourceManager.GetString("ArgMustBeGreaterThanOrEqualTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must be from the &apos;{0}&apos; enumeration..
        /// </summary>
        internal static string ArgumentOutOfRange_InvalidEnum {
            get {
                return ResourceManager.GetString("ArgumentOutOfRange_InvalidEnum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;unknown&gt;.
        /// </summary>
        internal static string Assembly_UnknownFileVersion {
            get {
                return ResourceManager.GetString("Assembly_UnknownFileVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operation failed due to a conflict: &apos;{0}&apos;..
        /// </summary>
        internal static string DomainManager_Conflict {
            get {
                return ResourceManager.GetString("DomainManager_Conflict", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The format of value &apos;{0}&apos; is invalid. The character &apos;{1}&apos; is not a valid HTTP header token character..
        /// </summary>
        internal static string HttpHeaderToken_Invalid {
            get {
                return ResourceManager.GetString("HttpHeaderToken_Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; cannot be null..
        /// </summary>
        internal static string Property_CannotBeNull {
            get {
                return ResourceManager.GetString("Property_CannotBeNull", resourceCulture);
            }
        }
    }
}
