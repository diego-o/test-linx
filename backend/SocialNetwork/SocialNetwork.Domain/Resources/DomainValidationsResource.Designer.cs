﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialNetwork.Domain.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DomainValidationsResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public DomainValidationsResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SocialNetwork.Domain.Resources.DomainValidationsResource", typeof(DomainValidationsResource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data de nascimento invalida, necessário ter mais que 16 anos.
        /// </summary>
        public static string AgeLessThan {
            get {
                return ResourceManager.GetString("AgeLessThan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-mail inválido.
        /// </summary>
        public static string EmailInvalid {
            get {
                return ResourceManager.GetString("EmailInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IdPerson deve ser maior que 0.
        /// </summary>
        public static string FeedIdPersonNotNull {
            get {
                return ResourceManager.GetString("FeedIdPersonNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mensagem do feed não pode ser vazia.
        /// </summary>
        public static string FeedMessageNotEpty {
            get {
                return ResourceManager.GetString("FeedMessageNotEpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data de nascimento invalida, pessoa com mais de 150 anos.
        /// </summary>
        public static string OlderThan {
            get {
                return ResourceManager.GetString("OlderThan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Senha inválida, deve conter no mínimo 8 caracteres, sendo pelo menos uma letra minúscula, uma letra maiúscula, um dígito, um caractere especial.
        /// </summary>
        public static string PasswordInvalid {
            get {
                return ResourceManager.GetString("PasswordInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nome da pessoa não pode ser vazio.
        /// </summary>
        public static string PersonNameEmpty {
            get {
                return ResourceManager.GetString("PersonNameEmpty", resourceCulture);
            }
        }
    }
}
