#pragma checksum "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d6b2c997c40180818c4729226a3acbea03dcc6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TraCuu.GiamKichSan.Pages.FamousPeople.Pages_FamousPeople_Create), @"mvc.1.0.razor-page", @"/Pages/FamousPeople/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d6b2c997c40180818c4729226a3acbea03dcc6c", @"/Pages/FamousPeople/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"999602ff74e607fa696f489bd0b7bcd69e7bfc48", @"/Pages/_ViewImports.cshtml")]
    public class Pages_FamousPeople_Create : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("panel panel-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    <h2>Thêm mới</h2>\r\n    <p>Thông tin những người nổi tiếng</p>\r\n    <div class=\"panel-group\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d6b2c997c40180818c4729226a3acbea03dcc6c5112", async() => {
                WriteLiteral("\r\n            <div class=\"panel-body\">\r\n                <div class=\"form-group\">\r\n                    <label for=\"alias\">Bí danh:</label><span class=\"text-danger\">*</span>\r\n                    <input type=\"text\" class=\"form-control\" name=\"alias\"");
                BeginWriteAttribute("value", " value=\"", 519, "\"", 560, 1);
#nullable restore
#line 11 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 527, Model.personCommunityModel.Alias, 527, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" maxlength=""100"" required>
                </div>
                <div class=""form-group"">
                    <label for=""name"">Họ và Tên:</label><span class=""text-danger"">*</span>
                    <input type=""text"" class=""form-control"" name=""name""");
                BeginWriteAttribute("value", " value=\"", 818, "\"", 858, 1);
#nullable restore
#line 15 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 826, Model.personCommunityModel.Name, 826, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" maxlength=""200"" required>
                </div>
                <div class=""form-group"">
                    <label for=""birthday"">Ngày sinh:</label><span class=""text-danger"">*</span>
                    <input type=""date"" class=""form-control"" name=""birthday""");
                BeginWriteAttribute("value", " value=\"", 1124, "\"", 1168, 1);
#nullable restore
#line 19 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 1132, Model.personCommunityModel.Birthday, 1132, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" maxlength=""22"" required>
                </div>
                <div class=""form-group"">
                    <label for=""address"">Nơi sinh:</label><span class=""text-danger"">*</span>
                    <input type=""text"" class=""form-control"" name=""address""");
                BeginWriteAttribute("value", " value=\"", 1430, "\"", 1473, 1);
#nullable restore
#line 23 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 1438, Model.personCommunityModel.Address, 1438, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" maxlength=""500"" required>
                </div>
                <div class=""form-group"">
                    <label for=""workCategoryID"">Nghề nghiệp:</label><span class=""text-danger"">*</span>
                    <select class=""form-control"" name=""workCategoryID"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d6b2c997c40180818c4729226a3acbea03dcc6c8353", async() => {
                    WriteLiteral("----");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 29 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
                         foreach (var item in Model.workCategoriesEntity)
                        {
                            if (item.ID == Model.personCommunityModel.WorkCategoryID)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d6b2c997c40180818c4729226a3acbea03dcc6c10021", async() => {
#nullable restore
#line 33 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
                                                             Write(item.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
                                   WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 34 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d6b2c997c40180818c4729226a3acbea03dcc6c12554", async() => {
#nullable restore
#line 37 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
                                                    Write(item.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
                                   WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 38 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </select>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"facebook\">Facebook</label>\r\n                    <input type=\"text\" class=\"form-control\" name=\"facebook\"");
                BeginWriteAttribute("value", " value=\"", 2572, "\"", 2616, 1);
#nullable restore
#line 44 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 2580, Model.personCommunityModel.Facebook, 2580, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" maxlength=\"500\">\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"youtube\">Youtube</label>\r\n                    <input type=\"text\" class=\"form-control\" name=\"youtube\"");
                BeginWriteAttribute("value", " value=\"", 2834, "\"", 2877, 1);
#nullable restore
#line 48 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 2842, Model.personCommunityModel.Youtube, 2842, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" maxlength=\"500\">\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"tiktok\">Tiktok</label>\r\n                    <input type=\"text\" class=\"form-control\" name=\"tiktok\"");
                BeginWriteAttribute("value", " value=\"", 3092, "\"", 3134, 1);
#nullable restore
#line 52 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 3100, Model.personCommunityModel.Tiktok, 3100, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" maxlength=\"500\">\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"wikipedia\">Wikipedia</label>\r\n                    <input type=\"text\" class=\"form-control\" name=\"wikipedia\"");
                BeginWriteAttribute("value", " value=\"", 3358, "\"", 3403, 1);
#nullable restore
#line 56 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 3366, Model.personCommunityModel.Wikipedia, 3366, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" maxlength=\"500\">\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label>Image</label>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5d6b2c997c40180818c4729226a3acbea03dcc6c17406", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 60 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.FileUploads);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"panel-footer\">\r\n                <br />\r\n                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 3755, "\"", 3793, 1);
#nullable restore
#line 65 "E:\GiamKichSan\GiamKichSan\TraCuu.GiamKichSan\Pages\FamousPeople\Create.cshtml"
WriteAttributeValue("", 3763, Model.personCommunityModel.ID, 3763, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button type=\"submit\" class=\"btn btn-primary mb-2\">Submit</button>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TraCuu.GiamKichSan.Pages.FamousPeople.CreateModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TraCuu.GiamKichSan.Pages.FamousPeople.CreateModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TraCuu.GiamKichSan.Pages.FamousPeople.CreateModel>)PageContext?.ViewData;
        public TraCuu.GiamKichSan.Pages.FamousPeople.CreateModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591