#pragma checksum "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d93b5656fbf32f26b20fa47b35b791bd34d1940"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TraCuu.GiamKichSan.Pages.FamousPeople.Pages_FamousPeople_Index), @"mvc.1.0.razor-page", @"/Pages/FamousPeople/Index.cshtml")]
namespace TraCuu.GiamKichSan.Pages.FamousPeople
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
#line 1 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\_ViewImports.cshtml"
using TraCuu.GiamKichSan;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d93b5656fbf32f26b20fa47b35b791bd34d1940", @"/Pages/FamousPeople/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"999602ff74e607fa696f489bd0b7bcd69e7bfc48", @"/Pages/_ViewImports.cshtml")]
    public class Pages_FamousPeople_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("panel panel-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d93b5656fbf32f26b20fa47b35b791bd34d19403726", async() => {
                WriteLiteral("\r\n    <div class=\"panel-heading\"></div>\r\n    <div class=\"panel-body\">\r\n        <div class=\"row form-group\">\r\n            <div class=\"col-md-6 col-sm-8\">\r\n                <input type=\"tel\" class=\"form-control\" name=\"term\"");
                BeginWriteAttribute("value", " value=\"", 331, "\"", 339, 0);
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Tra cứu\">\r\n            </div>\r\n            <div class=\"col-md-2 col-sm-4\">\r\n                <button type=\"submit\" class=\"btn btn-primary mb-2\">Tìm kiếm</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<div class=""table-responsive"">
    <table class=""table table-striped table-bordered table-hover table-condensed"">
        <thead>
            <tr style=""background-color: #104e8b; color: #e49b0f; text-align:center"">
                <th style=""width:50px"">STT</th>
                <th style=""width:50px"">Ảnh</th>
                <th style=""width:100px"">Bí danh</th>
                <th style=""width:150px"">Tên đầy đủ</th>
                <th style=""width:70px"">Ngày sinh</th>
                <th style=""width:200px"">Nơi sinh</th>
                <th style=""width:70px"">Wikipedia</th>
                <th style=""width:70px""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 31 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
               var index = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
             foreach (var item in Model.personCommunitiesModel)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
#nullable restore
#line 35 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
                       index++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 36 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
                   Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1526, "\"", 1543, 1);
#nullable restore
#line 38 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
WriteAttributeValue("", 1532, item.Image, 1532, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100%; height:100%; padding:0; margin:0;\" />\r\n                    </td>\r\n                    <td>");
#nullable restore
#line 40 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
                   Write(item.Alias);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 41 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 42 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
                   Write(item.Birthday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 43 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
                   Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1828, "\"", 1873, 1);
#nullable restore
#line 44 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
WriteAttributeValue("", 1835, item.Wikipedia.Replace("\"", "\\\" "), 1835, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 44 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
                                                                     Write(string.IsNullOrWhiteSpace(item.Wikipedia) ?"":"click here");

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1973, "\"", 2012, 2);
            WriteAttributeValue("", 1980, "\\FamousPeople\\Update?ID=", 1980, 24, true);
#nullable restore
#line 45 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
WriteAttributeValue("", 2004, item.ID, 2004, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Chỉnh sửa</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 47 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TraCuu.GiamKichSan.Pages.FamousPeople.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TraCuu.GiamKichSan.Pages.FamousPeople.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TraCuu.GiamKichSan.Pages.FamousPeople.IndexModel>)PageContext?.ViewData;
        public TraCuu.GiamKichSan.Pages.FamousPeople.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
