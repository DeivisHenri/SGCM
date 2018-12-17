using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.AppData.Infraestrutura
{
    public class CustomMetadataProvider : IDisplayMetadataProvider
    {
        public CustomMetadataProvider() { }

        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (context.PropertyAttributes != null)
            {

                foreach (object propAttr in context.PropertyAttributes)
                {
                    HTMLMaskAttribute addMetaAttr = propAttr as HTMLMaskAttribute;
                    if (addMetaAttr != null)
                    {
                        context.DisplayMetadata.AdditionalValues.Add
                                      (addMetaAttr.Name, addMetaAttr.Value);
                    }
                }
            }
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        public sealed class HTMLMaskAttribute : Attribute
        {
            public HTMLMaskAttribute() { }
            public HTMLMaskAttribute(string name, object value)
            {
                if (name == null)
                {
                    throw new ArgumentNullException("name");
                }
                Name = name;
                Value = value;
            }

            public string Name { get; private set; }
            public object Value { get; private set; }
        }
    }
}

