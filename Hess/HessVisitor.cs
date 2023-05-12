using Antlr4.Runtime.Misc;
using Hess;

namespace Hess;

public class HessVisitor : HessBaseVisitor<object?>
{
    public override object? VisitDefineBoard(HessParser.DefineBoardContext context)
    {
        var varName = context.BOARDPOSITION().GetText();
        return null;
    }
    
    public override object? VisitConstant(HessParser.ConstantContext context)
    {
        if (context.NATURAL_NUMBER() is { } i)
        {
            return int.Parse(i.GetText());
        }
        if (context.STRING() is { } s)
        {
            return s.GetText()[1..^1];
        }
        if (context.BOOL() is { } b)
        {
            return b.GetText() == "true";
        }
        if (context.NULL() is { })
        {
            return null;
        }

        throw new NotImplementedException();
    }

    public override object? VisitExpression(HessParser.ExpressionContext context)
    {
        if (context.constant() is { } c)
        {
            return Visit(context.constant());
        }
        else if (context.IDENTIFIER() is { } ID)
        {
            return context.GetText();
        }
        else
        {
            return null;
        }
    }

    public override object? VisitAssignment(HessParser.AssignmentContext context)
    {
        //Movelist
        if (context.moveList() != null)
        {
            var movelist = Visit(context.moveList());
            var assignmentIdentifier = context.IDENTIFIER().GetText();
            return movelist;
        }
        //Player
        else if (context.player() != null)
        {
            var playerValue = Visit(context.player());
            var assignmentIdentifier = context.IDENTIFIER().GetText();
            return playerValue;
        }
        //Expression
        else if (context.expression() != null)
        {
            var expressionValue = Visit(context.expression());
            var assignmentIdentifier = context.IDENTIFIER().GetText();
            return expressionValue;
        }

        return null;
    }

    public override object? VisitMoveExtra(HessParser.MoveExtraContext context)
    {
        List<object> moveExtraList = new List<object>();
        if (context.NATURAL_NUMBER(1) is { } N) {
            moveExtraList.Add(context.NATURAL_NUMBER(0));
            moveExtraList.Add(Visit(context.direction()));
            moveExtraList.Add(context.NATURAL_NUMBER(1));
        }
        else if (context.direction() is { } D)
        {
            moveExtraList.Add(Visit(context.direction()));
            moveExtraList.Add(context.NATURAL_NUMBER());
        }
        else
        {
            moveExtraList.Add(context.NATURAL_NUMBER());
        }
        return moveExtraList;
    }

    public override object? VisitDirection(HessParser.DirectionContext context)
    {
        return context.GetText();
    }

    public override object? VisitAttacktype(HessParser.AttacktypeContext context)
    {
        return context.GetText();
    }

    public override object? VisitCollision(HessParser.CollisionContext context)
    {
        return context.GetText() == "true";
    }

    public override object? VisitMovetype(HessParser.MovetypeContext context)
    {
        return context.GetText();
    }

    public override object? VisitMove(HessParser.MoveContext context)
    {
        List<object> move = new List<object>();
        move.Add(Visit(context.movetype()));
        move.Add(Visit(context.collision()));
        move.Add(Visit(context.attacktype()));
        move.Add(Visit(context.direction()));

        for (int i = 0; i < context.moveExtra().ChildCount; i++)
        {
            if (int.TryParse(context.moveExtra().GetChild(i).GetText(), out int j)) { 
                move.Add(int.Parse(context.moveExtra().GetChild(i).GetText()));
            }
            else { move.Add(context.moveExtra().GetChild(i).GetText()); }
        }
        return move;
    }

    public override object? VisitMoveList(HessParser.MoveListContext context)
    {
        List<object> moveList = new List<object>();

        for (int i = 0; i < context.GetText().Split(',').Length; i++)
        {
            moveList.Add(Visit(context.move(i)));
        }
        return moveList;
    }

    public override object? VisitBoardpositionlist(HessParser.BoardpositionlistContext context)
    {
        return context.GetText();
    }

    public override object? VisitPlace(HessParser.PlaceContext context)
    {
        List<object> placeList = new List<object>();
        placeList.Add(context.IDENTIFIER().GetText());
        placeList.Add(Visit(context.boardpositionlist()));
        return placeList;
    }

    public override object? VisitPlayer(HessParser.PlayerContext context)
    {
        List<object> playerList = new List<object>();
        for (int i = 0; i < context.ChildCount / 2; i++)
        {
            playerList.Add(Visit(context.place(i)));
        }
        return playerList;
    }

    public List<object> moveListParser(string input)
    {
        List<object> returnList = new List<object>();
        int count = 0;
        List<string[]> arguments = new List<string[]>();
        arguments.Add(new string[] { "Path", "Direct" });
        arguments.Add(new string[] { "true", "false" });
        arguments.Add(new string[] { "ATTACK", "MOVE", "ATKMOVE" });

        string[] directions = { "UP", "DOWN", "LEFT", "RIGHT" };

        foreach (string[] sArr in arguments)
        {
            foreach (string str in sArr)
            {
                string target = input.Substring(0, str.Length);
                if (target == str)
                {
                    input = input.Substring(str.Length);
                    returnList.Add(target);

                    break;
                }
            }
        }

        while (input.Length != 0)
        {
            if (int.TryParse(input.Substring(0, 1), out int num))
            {
                string number = input.Substring(0, 1);
                input = input.Substring(1);

                if (input.Length == 0)
                {
                    returnList.Add(number);
                    break;
                }
                while (int.TryParse(input.Substring(0, 1), out int num1))
                {
                    if (input.Length == 0)
                    {
                        returnList.Add(number);
                        break;
                    }
                    number += input.Substring(0, 1);
                    input = input.Substring(1);
                }
                returnList.Add(number);
            }
            else if (directions[count] == input.Substring(0, directions[count].Length))
            {
                input = input.Substring(directions[count].Length);
                returnList.Add(directions[count]);
                count = 0;
            }
            else
            {
                count++;
            }
        }

        return returnList;
    }
}
