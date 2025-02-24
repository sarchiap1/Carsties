// See https://aka.ms/new-console-template for more information
namespace consoleapp
{
    static class Program
    {
        static void Main(string[] args)
        {
            var config = new ParsingConfig
            {
                CustomTypeProvider = new CustomTypeProvider(),
                ResolveTypesBySimpleName = true,
            };

            var formula = "DQ.If( a > b, DQ.If( a < 500, DQ.And(a=c, c<3000), a > 100) , b > 200), c > 0)";
            var variables = new Dictionary<string, object>
            {
                { "a", 7 },
                { "b", 5 },
                { "c", 3 }
            };

            try
            {
                var lambda = DynamicExpressionParser.ParseLambda(
                    parsingConfig:config, 
                    null,
                    formula,
                    variables
                );
                var s_f = lambda.ToString();
                var lambdaCompiled = lambda.Compile();
                var result = lambdaCompiled.DynamicInvoke();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}