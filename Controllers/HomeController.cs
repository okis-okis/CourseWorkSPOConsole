using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onyx.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Onyx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Interpreter()
        {
            return View();
        }

        public IActionResult Code()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult InterpretCode()
        {
            String input = Request.Query["code"];
            TempData["code"] = input;

            //Lexical analysis
            Lexer lex = new Lexer(input);
            Token[] tokenList = lex.scan();

            //Output result of lexical analysis
            TempData["lex"] = getLexicalAnalysisResult(tokenList);
            TempData["lexResult"] = TempData["lex"].ToString().Split('\n').Last();

            if(TempData["lexResult"].ToString() == "Lexical analysis did successful")
            {
                TempData["lexType"] = "bg-success";
            }
            else
            {
                TempData["lexType"] = "bg-danger";
                return RedirectToAction("Interpreter");
            }

            //Syntax analysis
            Parser parser = new Parser(tokenList, lex.getValues());
            Node AST = parser.parse();
            
            String[] parserErrors = parser.getErrors();
            if (parserErrors.Length != 0)
            {
                TempData["parse"] = "";
                foreach (string error in parserErrors)
                    TempData["parse"] += error+"\n";

                TempData["parseType"] = "bg-danger";
                return RedirectToAction("Interpreter");
            }
            else
            {
                String parserRaport = parser.returnVar();
                parserRaport += parser.returnValues();
                TempData["parse"] = parserRaport;
                TempData["parseType"] = "bg-success";
            }
           

            TempData["RPN"] = new RPN().getPOLYZ(AST);
            TempData["RPNType"] = "bg-success";

            //Interpret code
            Interpreter interpreter = new Interpreter(AST,
                                                      parser.getStrings(),
                                                      parser.getFloats(),
                                                      parser.getVarArray()
                                                      );
            interpreter.interpret(true);

            parserErrors = interpreter.getErrors();
            if (parserErrors!=null&&parserErrors.Length != 0)
            {
                TempData["interpret"] = "";
                foreach (string error in parserErrors)
                    TempData["interpret"] += error + "\n";

                TempData["interpretType"] = "bg-danger";
                return RedirectToAction("Interpreter");
            }
            else
            {
                TempData["interpret"] = interpreter.getCode();
                TempData["interpretType"] = "bg-success";
            }

            return RedirectToAction("Interpreter");
        
        }

        static String getLexicalAnalysisResult(Token[] tokenList)
        {
            List<Token> errorToken = new List<Token>();
            int error = 0;

            String result = "";
            foreach (Token token in tokenList)
            {
                result += token.getTokenInfo();

                if (token.getTokenType() == TokenTypes.NOP)
                {
                    error++;
                    errorToken.Add(token);
                }

                result += "\n";
            }

            if (error != 0)
            {
                result += "\n==========================\n";
                result += "Error count: " + error+"\n";
                foreach (Token token in errorToken)
                {
                    result += token.getTokenInfo();
                }
                result += "\nLexical analysis have error(-s)";
                return result;
            }
            result+="\nLexical analysis did successful";
            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
