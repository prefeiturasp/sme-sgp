﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Security.Permissions;
using System.Web.Services.Description;
using System.Security.Cryptography;

namespace MSTech.GestaoEscolar.Web.WebProject.Util
{
    public class WsProxy
    {
        [SecurityPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public static object CallWebService(string webServiceAsmxUrl, string serviceName, string methodName, object[] args)
        {
            System.Net.WebClient client = new System.Net.WebClient();

            // Connect To the web service
            System.IO.Stream stream = client.OpenRead(webServiceAsmxUrl + "?wsdl");

            // Now read the WSDL file describing a service.
            ServiceDescription description = ServiceDescription.Read(stream);

            ///// LOAD THE DOM /////////

            // Initialize a service description importer.
            ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
            importer.ProtocolName = "Soap"; // Use SOAP 1.2.
            importer.AddServiceDescription(description, null, null);

            // Generate a proxy client.
            importer.Style = ServiceDescriptionImportStyle.Client;

            // Generate properties to represent primitive values.
            importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;

            // Initialize a Code-DOM tree into which we will import the service.
            CodeNamespace nmspace = new CodeNamespace();
            CodeCompileUnit unit1 = new CodeCompileUnit();
            unit1.Namespaces.Add(nmspace);

            // Import the service into the Code-DOM tree. This creates proxy code that uses the service.
            ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit1);

            if (warning == 0) // If zero then we are good to go
            {
                // Generate the proxy code
                CodeDomProvider provider1 = CodeDomProvider.CreateProvider("CSharp");

                // Compile the assembly proxy with the appropriate references
                string[] assemblyReferences = new string[5] { "System.dll", "System.Web.Services.dll", "System.Web.dll", "System.Xml.dll", "System.Data.dll" };
                CompilerParameters parms = new CompilerParameters(assemblyReferences);
                CompilerResults results = provider1.CompileAssemblyFromDom(parms, unit1);

                // Check For Errors
                if (results.Errors.Count > 0)
                {
                    foreach (CompilerError oops in results.Errors)
                    {
                        System.Diagnostics.Debug.WriteLine("========Compiler error============");
                        System.Diagnostics.Debug.WriteLine(oops.ErrorText);
                    }
                    throw new System.Exception("Compile Error Occured calling webservice. Check Debug ouput window.");
                }

                // Finally, Invoke the web service method
                object wsvcClass = results.CompiledAssembly.CreateInstance(serviceName);
                MethodInfo mi = wsvcClass.GetType().GetMethod(methodName);
                return mi.Invoke(wsvcClass, args);
            }
            else
            {
                return null;
            }
        }

        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
