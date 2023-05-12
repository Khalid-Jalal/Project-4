using Antlr4.Runtime;
using Hess;

var fileContent = File.ReadAllText("test.txt");
var inputStream = new AntlrInputStream(fileContent);
var hessLexer = new HessLexer(inputStream);
var commonTokenStream = new CommonTokenStream(hessLexer);
var hessParser = new HessParser(commonTokenStream);
var hessContext = hessParser.program();
var visitor = new HessVisitor();
visitor.Visit(hessContext);
