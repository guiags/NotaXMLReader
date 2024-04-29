using NotaXMLReader.src.NotaXMLReader.Application.Enums;

namespace NotaXMLReader.src.NotaXMLReader.Application;

public class ItemNotaXML
{
    public string nItem { get; set; } = string.Empty;
    public int Ncm {  get; set; }
    public int Cest {  get; set; }
    public int Cfop {  get; set; }
    public TipoItem TipoItem { get; set; }
}
