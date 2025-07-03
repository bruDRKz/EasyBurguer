using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EasyBurguer.TagHelpers
{
    [HtmlTargetElement("email")]
    public class EmailTagHelper : TagHelper
    {
        public string Endereco { get; set; }
        public string Conteudo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; // ESSENCIAL: substitui <email> por <a>
            output.TagMode = TagMode.StartTagAndEndTag; // Garante que tenha conteúdo
            output.Attributes.SetAttribute("href", "mailto:" + Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
