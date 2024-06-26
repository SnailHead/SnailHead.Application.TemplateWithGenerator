﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CodeGeneration.ServerCodeGenerator.Templates
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class EndpointTemplate : EndpointTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System.Threading.Tasks;\nusing Microsoft.AspNetCore.Mvc;\nusing Pepegov.MicroserviceFramework.ApiResults;\nusing Pepegov.MicroserviceFramework.AspNetCore.WebApi;\nusing Pepegov.MicroserviceFramework.Data.Exceptions;\nusing Service.TemplateController.BL.Services.Interfaces;\nusing Microsoft.AspNetCore.Authorization;\nusing Service.TemplateController.DAL.Entities;\nusing System.Net;\nusing Pepegov.UnitOfWork.Entityes;\nusing Service.TemplateController.PL.Models.Filters;\n\nnamespace Service.TemplateController.PL.EndPoints.");
            
            #line 14 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(";\n\npublic class ");
            
            #line 16 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("EndPoints : ApplicationDefinition\n{\n\tpublic override async Task ConfigureApplicationAsync(IDefinitionApplicationContext context)\n    {\n\t\tvar app = context.Parse<WebDefinitionApplicationContext>().WebApplication;\n\n        app.MapPost(\"~/api/");
            
            #line 22 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalToKebabCase()));
            
            #line default
            #line hidden
            this.Write("/create\", Create)\n            .WithOpenApi()\n            .WithSummary(\"Create ");
            
            #line 24 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalWithSpace()));
            
            #line default
            #line hidden
            this.Write("\")\n            .WithTags(\"");
            
            #line 25 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\");\n\n\t\tapp.MapPost(\"~/api/");
            
            #line 27 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalToKebabCase()));
            
            #line default
            #line hidden
            this.Write("/update\", Update)\n            .WithOpenApi()\n            .WithSummary(\"Update ");
            
            #line 29 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalWithSpace()));
            
            #line default
            #line hidden
            this.Write("\")\n            .WithTags(\"");
            
            #line 30 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\");\n\n\t\tapp.MapGet(\"~/api/");
            
            #line 32 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalToKebabCase()));
            
            #line default
            #line hidden
            this.Write("/get-by-id\", GetById)\n            .WithOpenApi()\n            .WithSummary(\"Get ");
            
            #line 34 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalWithSpace()));
            
            #line default
            #line hidden
            this.Write(" by id\")\n            .WithTags(\"");
            
            #line 35 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\");\n\n\t\tapp.MapDelete(\"~/api/");
            
            #line 37 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalToKebabCase()));
            
            #line default
            #line hidden
            this.Write("/delete\", Delete)\n            .WithOpenApi()\n            .WithSummary(\"Delete ");
            
            #line 39 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalWithSpace()));
            
            #line default
            #line hidden
            this.Write("\")\n            .WithTags(\"");
            
            #line 40 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\");\n\n\t\t");
            
            #line 42 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
if (NeedFilter)
		{
            
            #line default
            #line hidden
            this.Write("app.MapPost(\"~/api/");
            
            #line 43 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalToKebabCase()));
            
            #line default
            #line hidden
            this.Write("/get-paged-list\", GetPagedList)\n\t        .WithOpenApi()\n\t        .WithSummary(\"Get paged list by filter ");
            
            #line 45 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalWithSpace()));
            
            #line default
            #line hidden
            this.Write("\")\n\t        .WithTags(\"");
            
            #line 46 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\");\n\t\t");
            
            #line 47 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
} else {
            
            #line default
            #line hidden
            this.Write("app.MapGet(\"~/api/");
            
            #line 47 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalToKebabCase()));
            
            #line default
            #line hidden
            this.Write("/get-paged-list\", GetPagedList)\n            .WithOpenApi()\n            .WithSummary(\"Get ");
            
            #line 49 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName.PascalWithSpace()));
            
            #line default
            #line hidden
            this.Write(" paged list\")\n            .WithTags(\"");
            
            #line 50 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\");\n\t\t");
            
            #line 51 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("\t}\n\n\t[ProducesResponseType(200, Type = typeof(ApiResult<");
            
            #line 54 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(">))]\n    [ProducesResponseType(401)]\n    [ProducesResponseType(403)]\n    [ProducesResponseType(404, Type = typeof(ApiResult))]\n    [FeatureGroupName(\"");
            
            #line 58 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\")]\n    private async Task<IResult> Create(HttpContext context,\n        [FromServices] I");
            
            #line 60 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 60 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName.ToFirstLower()));
            
            #line default
            #line hidden
            this.Write(",\n        [FromBody] ");
            
            #line 61 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(" model,\n        CancellationToken cancellationToken)\n    {\n        var result = await ");
            
            #line 64 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName.ToFirstLower()));
            
            #line default
            #line hidden
            this.Write(".CreateAsync(model, cancellationToken: cancellationToken);\n\t\tif (result is null)\n\t\t{\n\t\t\treturn Results.Extensions.Custom(new ApiResult<");
            
            #line 67 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(">(HttpStatusCode.BadRequest, new MicroserviceInvalidOperationException(\"Update ");
            
            #line 67 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.Name));
            
            #line default
            #line hidden
            this.Write(" failed\")));\n\t\t}\n\t\treturn Results.Extensions.Custom(new ApiResult<");
            
            #line 69 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.Name));
            
            #line default
            #line hidden
            this.Write(">(model, HttpStatusCode.OK));\n    }\n\n\t[ProducesResponseType(200, Type = typeof(ApiResult<");
            
            #line 72 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(">))]\n    [ProducesResponseType(401)]\n    [ProducesResponseType(403)]\n    [ProducesResponseType(404, Type = typeof(ApiResult))]\n    [FeatureGroupName(\"");
            
            #line 76 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\")]\n    private async Task<IResult> Update(HttpContext context,\n        [FromServices] I");
            
            #line 78 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 78 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName.ToFirstLower()));
            
            #line default
            #line hidden
            this.Write(",\n        [FromBody] ");
            
            #line 79 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(" model,\n        CancellationToken cancellationToken)\n    {\n        var result = await ");
            
            #line 82 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName.ToFirstLower()));
            
            #line default
            #line hidden
            this.Write(".UpdateAsync(model, cancellationToken: cancellationToken);\n\t\tif (result is null)\n\t\t{\n\t\t\treturn Results.Extensions.Custom(new ApiResult<");
            
            #line 85 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(">(HttpStatusCode.BadRequest, new MicroserviceInvalidOperationException(\"Update ");
            
            #line 85 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.Name));
            
            #line default
            #line hidden
            this.Write(" failed\")));\n\t\t}\n\t\treturn Results.Extensions.Custom(new ApiResult<");
            
            #line 87 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.Name));
            
            #line default
            #line hidden
            this.Write(">(model, HttpStatusCode.OK));\n    }\n\n\t[ProducesResponseType(200, Type = typeof(ApiResult<");
            
            #line 90 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(">))]\n    [ProducesResponseType(401)]\n    [ProducesResponseType(403)]\n    [ProducesResponseType(404, Type = typeof(ApiResult))]\n    [FeatureGroupName(\"");
            
            #line 94 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write("\")]\n    private async Task<IResult> GetById(HttpContext context,\n        [FromServices] I");
            
            #line 96 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 96 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName.ToFirstLower()));
            
            #line default
            #line hidden
            this.Write(",\n        [FromQuery] Guid id,\n        CancellationToken cancellationToken)\n    {\n        var result = await ");
            
            #line 100 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ServiceName.ToFirstLower()));
            
            #line default
            #line hidden
            this.Write(".GetByIdAsync(id, cancellationToken: cancellationToken);\n\t\tif (result is null)\n\t\t{\n\t\t\treturn Results.Extensions.Custom(new ApiResult<");
            
            #line 103 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.PluralName));
            
            #line default
            #line hidden
            this.Write(">(HttpStatusCode.BadRequest, new MicroserviceInvalidOperationException(\"Update ");
            
            #line 103 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.Name));
            
            #line default
            #line hidden
            this.Write(" failed\")));\n\t\t}\n\t\treturn Results.Extensions.Custom(new ApiResult<");
            
            #line 105 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityDescription.Name));
            
            #line default
            #line hidden
            this.Write(">(model, HttpStatusCode.OK));\n    }\n\n}\n\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 110 "/Users/aleksejromanov/Desktop/Projects/Service.TemplateController/src/Service.TemplateController.CodeGenerator/Templates/EndpointTemplate.tt"

	internal EntityDescription EntityDescription;
	internal int MaxLineWidth;
	internal bool NeedFilter;
	internal string ServiceName;
	internal EndpointTemplate(EntityDescription entityDescription, int maxLineWidth) {
		EntityDescription = entityDescription;
		MaxLineWidth = maxLineWidth;
		NeedFilter = entityDescription.FilterProperties.Count > 0;
		ServiceName = EntityDescription.PluralName + "Service";
	}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal class EndpointTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
