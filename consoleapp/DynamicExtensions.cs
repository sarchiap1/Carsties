using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace consoleapp;

public class DQ
{
    public static object And(object left, object right)
    {
        var c_left = left as bool?;
        var c_right = right as bool?;
        return c_left.HasValue && c_right.HasValue && c_left.Value && c_right.Value ? true : false; 
    }
    public static object If(object condition, object trueValue, object falseValue)
    {
        var c = condition as bool?;
        return (c.Value) ? trueValue : falseValue;
    }
    /*
    public static object If(string condition, string trueExpression, string falseExpression, IDictionary<string, object> variables)
    {
        var substitutedCondition = SubstituteVariables(condition, variables);
        
        var conditionResult = EvaluateExpression(substitutedCondition, variables);
        
        var expressionToEvaluate = (bool)conditionResult ? trueExpression : falseExpression;
        
        var substitutedExpression = SubstituteVariables(expressionToEvaluate, variables);
        return EvaluateExpression(substitutedExpression, variables);
    }*/
    
    public static string SubstituteVariables(string expression, IDictionary<string, object> variables)
    {
        foreach (var variable in variables)
        {
            expression = expression.Replace(variable.Key, variable.Value.ToString());
        }
        return expression;
    }
    
    private static object EvaluateExpression(string expression, IDictionary<string, object> variables)
    {
        var lambda = DynamicExpressionParser.ParseLambda(
            variables.GetType(),
            typeof(object),
            expression
        );
        return lambda.Compile().DynamicInvoke();
    }
    
    private static object EvaluateFormula(string formula, IDictionary<string, object> variables, ParsingConfig config)
    {
        formula = SubstituteVariables(formula, variables);
        
        var lambda = DynamicExpressionParser.ParseLambda(
            variables.GetType(), 
            typeof(object),      
            formula,
            config,
            variables
        );
        return lambda.Compile().DynamicInvoke(variables);
    }
}