#pragma checksum "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b60e90acacec84c3a1aa21530ff1466bf75e1860"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MusicApp.Pages.Bands.Pages_Bands_Details), @"mvc.1.0.razor-page", @"/Pages/Bands/Details.cshtml")]
namespace MusicApp.Pages.Bands
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\_ViewImports.cshtml"
using MusicApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\_ViewImports.cshtml"
using MusicApp.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id:int}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b60e90acacec84c3a1aa21530ff1466bf75e1860", @"/Pages/Bands/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de109d43cad6955c0f04d06fdf3d601394304696", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Bands_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 8 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<h2>Contact</h2>\r\n\r\n<dl>\r\n    <dt>");
#nullable restore
#line 13 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml"
   Write(Html.DisplayNameFor(m => m.Band.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dd>");
#nullable restore
#line 14 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml"
   Write(Model.Band.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>");
#nullable restore
#line 15 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml"
   Write(Html.DisplayNameFor(m => m.Band.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dd>");
#nullable restore
#line 16 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml"
   Write(Model.Band.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>");
#nullable restore
#line 17 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml"
   Write(Html.DisplayNameFor(m => m.Band.YearFormed));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n    <dd>");
#nullable restore
#line 18 "C:\Users\Jörgen\source\repos\MusicApp\MusicApp\Pages\Bands\Details.cshtml"
   Write(Model.Band.YearFormed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n</dl>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b60e90acacec84c3a1aa21530ff1466bf75e18605644", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MusicApp.Pages.Bands.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MusicApp.Pages.Bands.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MusicApp.Pages.Bands.DetailsModel>)PageContext?.ViewData;
        public MusicApp.Pages.Bands.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591