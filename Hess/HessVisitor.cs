using Antlr4.Runtime.Misc;
using Hess;
using System.Reflection;
using System.IO;
using System;

namespace Hess;

public class HessVisitor : HessBaseVisitor<object?>
{
    Dictionary<string, object?> bookOfWisdom = new Dictionary<string, object?>();
    char[] alphabet =
    {
        'A',
        'B',
        'C',
        'D',
        'E',
        'F',
        'G',
        'H',
        'I',
        'J',
        'K',
        'L',
        'M',
        'N',
        'O',
        'P',
        'Q',
        'R',
        'S',
        'T',
        'U',
        'V',
        'W',
        'X',
        'Y',
        'Z'
    };

    public override object? VisitDefineBoard(HessParser.DefineBoardContext context)
    {
        var boardSize = context.BOARDPOSITION().GetText();
        UpdateElseAdd("BOARD", boardSize);
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
            var moveListID = context.IDENTIFIER().GetText();
            var moveListValue = Visit(context.moveList());
            UpdateElseAdd(moveListID, moveListValue);
            return moveListValue;
        }
        //Player
        else if (context.player() != null)
        {
            var playerID = context.IDENTIFIER().GetText();
            var playerValue = Visit(context.player());
            UpdateElseAdd(playerID, playerValue);
            return playerValue;
        }
        //Expression
        else if (context.expression() != null)
        {
            var expressionID = context.IDENTIFIER().GetText();
            var expressionValue = Visit(context.expression());
            UpdateElseAdd(expressionID, expressionValue);
            return expressionValue;
        }
        //Place
        else if (context.place() != null)
        {
            var placeID = context.IDENTIFIER().GetText();
            var placeValue = Visit(context.place());
            UpdateElseAdd(placeID, placeValue);

            return placeValue;
        }

        return null;
    }

    public override object? VisitMoveExtra(HessParser.MoveExtraContext context)
    {
        List<object?> moveExtraList = new List<object?>();
        if (context.NATURAL_NUMBER(1) is { } N)
        {
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
        List<object?> move = new List<object?>();
        move.Add(Visit(context.movetype()));
        move.Add(Visit(context.collision()));
        move.Add(Visit(context.attacktype()));
        move.Add(Visit(context.direction()));

        for (int i = 0; i < context.moveExtra().ChildCount; i++)
        {
            if (int.TryParse(context.moveExtra().GetChild(i).GetText(), out int j))
            {
                move.Add(int.Parse(context.moveExtra().GetChild(i).GetText()));
            }
            else
            {
                move.Add(context.moveExtra().GetChild(i).GetText());
            }
        }
        return move;
    }

    public override object? VisitMoveList(HessParser.MoveListContext context)
    {
        List<object?> moveList = new List<object?>();

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
        List<object?> placeList = new List<object?>();
        placeList.Add(context.IDENTIFIER().GetText());
        placeList.Add(Visit(context.boardpositionlist()));
        return placeList;
    }

    public override object? VisitPlaceType(HessParser.PlaceTypeContext context)
    {
        if (context.place() != null)
        {
            return Visit(context.place());
        }
        else
        {
            return context.IDENTIFIER().GetText();
        }
    }

    public override object? VisitPlayer(HessParser.PlayerContext context)
    {
        List<object?> playerList = new List<object?>();
        for (int i = 0; i < context.ChildCount / 2; i++)
        {
            playerList.Add(Visit(context.placeType(i)));
        }
        return playerList;
    }

    //BOOKOFWISDOM FUNCTIONS
    public bool UpdateElseAdd(string ID, object? value)
    {
        foreach (var element in bookOfWisdom)
        {
            if (ID == element.Key)
            {
                bookOfWisdom.Remove(element.Key);
                bookOfWisdom.Add(ID, value);
                return true;
            }
        }
        bookOfWisdom.Add(ID, value);
        return true;
    }

    public object? bookOfWisdomParser(string ID)
    {
        foreach (var element in bookOfWisdom)
        {
            if (ID == element.Key)
            {
                return element.Value;
            }
        }
        return null;
    }

    public int[] boardPosToValue(string? boardPos)
    {
        char letter = char.Parse(boardPos.Substring(0, 1));
        int letterValue = 1;
        foreach (char c in alphabet)
        {
            if (letter == c)
            {
                break;
            }
            letterValue++;
        }

        var boardValue = int.Parse(boardPos.Substring(1, boardPos.Length - 1));

        return new int[] { letterValue, boardValue };
    }

    public List<object> PlaceListUpdate(object place)
    {
        List<object> placeList = new List<object>();

        var placeCast = (List<object>)place;
        foreach (object obj in placeCast)
        {
            if (obj is string)
            {
                placeList.Add(bookOfWisdomParser(obj.ToString()));
            }
            else
            {
                placeList.Add(obj);
            }
        }
        return placeList;
    }

    Dictionary<string, List<int[]>> PlayerListParser(List<object> playerList)
    {
        Dictionary<string, List<int[]>> returnDic = new Dictionary<string, List<int[]>>();

        for (int i = 0; i < playerList.Count; i++)
        {
            List<int[]> boardPosList = new List<int[]>();
            List<object> typecasted = (List<object>)playerList[i];
            var piece_name = typecasted[0].ToString();
            var place_location_list = typecasted[1].ToString().Split('{', ',', '}');

            for (int j = 1; j < (place_location_list.Length - 1); j++)
            {
                boardPosList.Add(boardPosToValue(place_location_list[j]));
            }
            if (returnDic.ContainsKey(piece_name))
            {
                returnDic[piece_name] = returnDic[piece_name].Concat(boardPosList).ToList();
            }
            else
            {
                returnDic.Add(piece_name, boardPosList);
            }
        }

        return returnDic;
    }

    public string[,] NameAndPlace(
        string playerID,
        Dictionary<string, List<int[]>> dic,
        string[,] board
    )
    {
        foreach (var element in dic)
        {
            var indexer = 1;
            var coordinates = element.Value;

            foreach (var coordinate in coordinates)
            {
                var ID = playerID + "_" + element.Key + "_" + indexer;
                if (board[coordinate[0] - 1, coordinate[1] - 1] == "0")
                {
                    board[coordinate[0] - 1, coordinate[1] - 1] = ID;
                }
                else
                {
                    string exception =
                        "Attempted to place "
                        + element.Key
                        + " on ["
                        + coordinate[0]
                        + ","
                        + coordinate[1]
                        + "] which was already occupied by "
                        + board[coordinate[0], coordinate[1]];
                    throw new Exception(exception);
                }
                indexer++;
            }
        }

        return board;
    }

    public string[,] PlacePieces(string[,] board, object player, string playerID)
    {
        List<object> playerList1 = (List<object>)player;
        List<int[]> boardPosList = new List<int[]>();

        Dictionary<string, List<int[]>> P1PlaceLoc = PlayerListParser(playerList1);

        // name on piece -> {PLAYER_NAME}_{PIECE_NAME}_{PIECE_ID}

        board = NameAndPlace(playerID, P1PlaceLoc, board);

        return board;
    }

    public void PrintBoard(string[,] board)
    {
        Console.Clear();
        for (int i = board.GetLength(1) + 1; i > 1; i--)
        {
            Console.Write("   ");
            for (int j = 1; j < board.GetLength(0) + 1; j++)
            {
                Console.Write("x------");
            }
            Console.WriteLine("x");
            if ((i - 1) >= 10)
            {
                Console.Write(i - 1 + " |");
            }
            else
            {
                Console.Write(i - 1 + "  |");
            }
            for (int j = 1; j < board.GetLength(0) + 1; j++)
            {
                if (board[j - 1, i - 2] != "0")
                {
                    if (board[j - 1, i - 2].Substring(0, 8) == "Spiller1")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (board[j - 1, i - 2].Substring(0, 8) == "Spiller2")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(" {0} ", board[j - 1, i - 2].Substring(9, 4));
                    Console.ResetColor();
                    Console.Write("|");
                }
                else
                {
                    Console.Write("      |");
                }
            }
            Console.WriteLine();
        }
        Console.Write("   ");
        for (int j = 1; j < board.GetLength(0) + 1; j++)
        {
            Console.Write("x------");
        }
        Console.Write("x");
        Console.WriteLine();

        string boardLetter = bookOfWisdomParser("BOARD").ToString().Substring(0, 1);
        char letter = char.Parse(boardLetter);

        Console.Write("      ");
        for (int i = 0; i < alphabet.Length; i++)
        {
            Console.Write(alphabet[i] + "      ");
            if (alphabet[i] == letter)
            {
                break;
            }
        }
        Console.WriteLine();
    }

    public int[,] GetMoves(
        List<object> moveList,
        int[] pieceLocation,
        List<int[]> allPieceLocations,
        string[,] board
    )
    {
        string[,] viable_moves = new string[board.GetLength(0), board.GetLength(1)];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                viable_moves[i, j] = "0";
                if (i == pieceLocation[0] && j == pieceLocation[1])
                {
                    viable_moves[i, j] = "1";
                }
            }
        }

        for (int k = 0; k < allPieceLocations.Count; k++)
        {
            if (viable_moves[allPieceLocations[k][0], allPieceLocations[k][1]] != "1")
            {
                viable_moves[allPieceLocations[k][0], allPieceLocations[k][1]] = "2";
            }
        }

        foreach (var move in moveList)
        {
            var typecasted = (List<object>)move;
            var move_length = typecasted.Count;
            var move_type = (string)typecasted[0];
            bool collision_type = (bool)typecasted[1];
            var attack_type = typecasted[2];

            string direction1 = "0";
            int direction_int = 0;
            string direction2 = "0";
            int direction2_int = 0;

            if (move_length == 5)
            {
                direction1 = typecasted[3].ToString();
                direction_int = (int)typecasted[4];

                if (move_type == "Path" && collision_type is true)
                {
                    for (int i = 0; i < viable_moves.GetLength(0); i++)
                    {
                        for (int j = 0; j < viable_moves.GetLength(1); j++)
                        {
                            //UP
                            if (
                                (j > pieceLocation[0] && i == pieceLocation[1])
                                && direction1 == "UP"
                            )
                            {
                                //MOVABLE SPOT ON BOARD
                                if ((viable_moves[i, j] == "0"))
                                {
                                    viable_moves[i, j] = "3";
                                }
                                //ATTACKBLE SPOT ON BOARD
                                else if (viable_moves[i, j] == "2")
                                {
                                    viable_moves[i, j] = "4";
                                    break;
                                }
                            }
                            //DOWN
                            if (
                                (j < pieceLocation[0] && i == pieceLocation[1])
                                && direction1 == "DOWN"
                            )
                            {
                                //MOVABLE SPOT ON BOARD
                                if (viable_moves[i, j] == "0")
                                {
                                    viable_moves[i, j] = "3";
                                }
                                //ATTACKBLE SPOT ON BOARD
                                else if (viable_moves[i, j] == "2")
                                {
                                    viable_moves[i, j] = "4";
                                    break;
                                }
                            }
                            //RIGHT
                            if (
                                (i > pieceLocation[1] && j == pieceLocation[0])
                                && direction1 == "RIGHT"
                            )
                            {
                                //MOVABLE SPOT ON BOARD
                                if (viable_moves[i, j] == "0")
                                {
                                    viable_moves[i, j] = "3";
                                }
                                //ATTACKBLE SPOT ON BOARD
                                else if (viable_moves[i, j] == "2")
                                {
                                    viable_moves[i, j] = "4";
                                    break;
                                }
                            }
                            //LEFT
                            if (
                                (i < pieceLocation[1] && j == pieceLocation[0])
                                && direction1 == "LEFT"
                            )
                            {
                                //MOVABLE SPOT ON BOARD
                                if (viable_moves[i, j] == "0")
                                {
                                    viable_moves[i, j] = "3";
                                }
                                //ATTACKBLE SPOT ON BOARD
                                else if (viable_moves[i, j] == "2")
                                {
                                    viable_moves[i, j] = "4";
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (move_type == "Path" && !collision_type)
                {
                    for (int i = 0; i < viable_moves.GetLength(0); i++)
                    {
                        for (int j = 0; j < viable_moves.GetLength(1); j++)
                        {
                            //UP
                            if (
                                (j > pieceLocation[0] && i == pieceLocation[1])
                                && direction1 == "UP"
                            )
                            {
                                //MOVABLE SPOT ON BOARD
                                if ((viable_moves[i, j] == "0"))
                                {
                                    viable_moves[i, j] = "3";
                                }
                                //ATTACKBLE SPOT ON BOARD
                                else if (viable_moves[i, j] == "2")
                                {
                                    viable_moves[i, j] = "4";
                                }
                            }
                            //DOWN
                            if (
                                (j < pieceLocation[0] && i == pieceLocation[1])
                                && direction1 == "DOWN"
                            )
                            {
                                //MOVABLE SPOT ON BOARD
                                if (viable_moves[i, j] == "0")
                                {
                                    viable_moves[i, j] = "3";
                                }
                                //ATTACKBLE SPOT ON BOARD
                                else if (viable_moves[i, j] == "2")
                                {
                                    viable_moves[i, j] = "4";
                                }
                            }
                            //RIGHT
                            if (
                                (i > pieceLocation[1] && j == pieceLocation[0])
                                && direction1 == "RIGHT"
                            )
                            {
                                //MOVABLE SPOT ON BOARD
                                if (viable_moves[i, j] == "0")
                                {
                                    viable_moves[i, j] = "3";
                                }
                                //ATTACKBLE SPOT ON BOARD
                                else if (viable_moves[i, j] == "2")
                                {
                                    viable_moves[i, j] = "4";
                                }
                            }
                            //LEFT
                            if (
                                (i < pieceLocation[1] && j == pieceLocation[0])
                                && direction1 == "LEFT"
                            )
                            {
                                //MOVABLE SPOT ON BOARD
                                if (viable_moves[i, j] == "0")
                                {
                                    viable_moves[i, j] = "3";
                                }
                                //ATTACKBLE SPOT ON BOARD
                                else if (viable_moves[i, j] == "2")
                                {
                                    viable_moves[i, j] = "4";
                                }
                            }
                        }
                    }
                }
            }
            else if (move_type == "Direct" && collision_type)
            {
                for (int i = 0; i < viable_moves.GetLength(0); i++)
                {
                    for (int j = 0; j < viable_moves.GetLength(1); j++)
                    {
                        //UP
                        if ((j > pieceLocation[0] && i == pieceLocation[1]) && direction1 == "UP")
                        {
                            //Detected collision before reaching inteded spot
                            if (viable_moves[i, j] == "2")
                            {
                                break;
                            }
                            //Detected empty spot on direct location
                            else if (
                                (i == pieceLocation[0])
                                && (j == pieceLocation[1] + direction_int)
                                && (
                                    viable_moves[
                                        pieceLocation[0],
                                        (pieceLocation[1] + direction_int)
                                    ] == "0"
                                )
                            )
                            {
                                viable_moves[i, j] = "3";
                            }
                            //Detected opponent on direct location
                            else if (
                                (i == pieceLocation[0])
                                && (j == pieceLocation[1] + direction_int)
                                && (
                                    viable_moves[
                                        pieceLocation[0],
                                        (pieceLocation[1] + direction_int)
                                    ] == "2"
                                )
                            )
                            {
                                viable_moves[i, j] = "4";
                            }
                        }
                        //DOWN
                        if ((j < pieceLocation[0] && i == pieceLocation[1]) && direction1 == "DOWN")
                        {
                            //Detected collision before reaching inteded spot
                            if (viable_moves[i, j] == "2")
                            {
                                break;
                            }
                            //Detected empty spot on direct location
                            else if (
                                (i == pieceLocation[0])
                                && (j == pieceLocation[1] - direction_int)
                                && (
                                    viable_moves[
                                        pieceLocation[0],
                                        (pieceLocation[1] - direction_int)
                                    ] == "0"
                                )
                            )
                            {
                                viable_moves[i, j] = "3";
                            }
                            //Detected opponent on direct location
                            else if (
                                (i == pieceLocation[0])
                                && (j == pieceLocation[1] - direction_int)
                                && (
                                    viable_moves[
                                        pieceLocation[0],
                                        (pieceLocation[1] - direction_int)
                                    ] == "2"
                                )
                            )
                            {
                                viable_moves[i, j] = "4";
                            }
                        }
                        //RIGHT
                        if (
                            (i > pieceLocation[1] && j == pieceLocation[0]) && direction1 == "RIGHT"
                        )
                        {
                            //Detected collision before reaching inteded spot
                            if (viable_moves[i, j] == "2")
                            {
                                break;
                            }
                            //Detected empty spot on direct location
                            else if (
                                (i == pieceLocation[0])
                                && (j == pieceLocation[1] + direction_int)
                                && (
                                    viable_moves[
                                        pieceLocation[0],
                                        (pieceLocation[1] + direction_int)
                                    ] == "0"
                                )
                            )
                            {
                                viable_moves[i, j] = "3";
                            }
                            //Detected opponent on direct location
                            else if (
                                (i == pieceLocation[0])
                                && (j == pieceLocation[1] + direction_int)
                                && (
                                    viable_moves[
                                        pieceLocation[0],
                                        (pieceLocation[1] + direction_int)
                                    ] == "2"
                                )
                            )
                            {
                                viable_moves[i, j] = "4";
                            }
                        }
                        //LEFT
                        if ((i < pieceLocation[1] && j == pieceLocation[0]) && direction1 == "LEFT")
                        {
                            //Detected collision before reaching inteded spot
                            if (viable_moves[i, j] == "2")
                            {
                                break;
                            }
                            //Detected empty spot on direct location
                            else if (
                                (i == pieceLocation[0])
                                && (j == pieceLocation[1] - direction_int)
                                && (
                                    viable_moves[
                                        pieceLocation[0],
                                        (pieceLocation[1] - direction_int)
                                    ] == "0"
                                )
                            )
                            {
                                viable_moves[i, j] = "3";
                            }
                            //Detected opponent on direct location
                            else if (
                                (i == pieceLocation[0])
                                && (j == pieceLocation[1] - direction_int)
                                && (
                                    viable_moves[
                                        pieceLocation[0],
                                        (pieceLocation[1] - direction_int)
                                    ] == "2"
                                )
                            )
                            {
                                viable_moves[i, j] = "4";
                            }
                        }
                    }
                }
            }
            else if (move_type == "Direct" && !collision_type)
            {
                for (int i = 0; i < viable_moves.GetLength(0); i++)
                {
                    for (int j = 0; j < viable_moves.GetLength(1); j++)
                    {
                        //UP
                        if ((j > pieceLocation[0] && i == pieceLocation[1]) && direction1 == "UP")
                        {
                            if (
                                j == (pieceLocation[0] + direction_int)
                                && viable_moves[
                                    (pieceLocation[0] + direction_int),
                                    pieceLocation[1]
                                ] == "0"
                            )
                            {
                                viable_moves[(pieceLocation[0] + direction_int), pieceLocation[1]] =
                                    "3";
                            }
                            else if (
                                j == (pieceLocation[0] + direction_int)
                                && viable_moves[
                                    (pieceLocation[0] + direction_int),
                                    pieceLocation[1]
                                ] == "2"
                            )
                            {
                                viable_moves[(pieceLocation[0] + direction_int), pieceLocation[1]] =
                                    "4";
                            }
                        }
                        //DOWN
                        if ((j < pieceLocation[0] && i == pieceLocation[1]) && direction1 == "DOWN")
                        {
                            if (
                                j == (pieceLocation[0] - direction_int)
                                && viable_moves[
                                    (pieceLocation[0] - direction_int),
                                    pieceLocation[1]
                                ] == "0"
                            )
                            {
                                viable_moves[(pieceLocation[0] - direction_int), pieceLocation[1]] =
                                    "3";
                            }
                            else if (
                                j == (pieceLocation[0] - direction_int)
                                && viable_moves[
                                    (pieceLocation[0] - direction_int),
                                    pieceLocation[1]
                                ] == "2"
                            )
                            {
                                viable_moves[(pieceLocation[0] - direction_int), pieceLocation[1]] =
                                    "4";
                            }
                        }
                        //RIGHT
                        if (
                            (i > pieceLocation[1] && j == pieceLocation[0]) && direction1 == "RIGHT"
                        )
                        {
                            if (
                                i == (pieceLocation[1] + direction_int)
                                && viable_moves[
                                    (pieceLocation[0]),
                                    pieceLocation[1] + direction_int
                                ] == "0"
                            )
                            {
                                viable_moves[(pieceLocation[0] + direction_int), pieceLocation[1]] =
                                    "3";
                            }
                            else if (
                                i == (pieceLocation[0] + direction_int)
                                && viable_moves[
                                    (pieceLocation[0]),
                                    pieceLocation[1] + direction_int
                                ] == "2"
                            )
                            {
                                viable_moves[(pieceLocation[0] + direction_int), pieceLocation[1]] =
                                    "4";
                            }
                        }
                        //LEFT
                        if ((i < pieceLocation[1] && j == pieceLocation[0]) && direction1 == "LEFT")
                        {
                            if (
                                i == (pieceLocation[1] - direction_int)
                                && viable_moves[
                                    (pieceLocation[0]),
                                    pieceLocation[1] - direction_int
                                ] == "0"
                            )
                            {
                                viable_moves[(pieceLocation[0]), pieceLocation[1] - direction_int] =
                                    "3";
                            }
                            else if (
                                i == (pieceLocation[1] - direction_int)
                                && viable_moves[
                                    (pieceLocation[0] - direction_int),
                                    pieceLocation[1]
                                ] == "2"
                            )
                            {
                                viable_moves[(pieceLocation[0]), pieceLocation[1] - direction_int] =
                                    "4";
                            }
                        }
                    }
                }
            }
            else if (move_length == 6)
            {
                direction1 = typecasted[3].ToString();
                direction2 = typecasted[4].ToString();
                direction_int = (int)typecasted[5];
            }
            else if (move_length == 7)
            {
                direction1 = typecasted[3].ToString();
                direction_int = (int)typecasted[4];
                direction2 = typecasted[5].ToString();
                direction2_int = (int)typecasted[6];
            }
        }

        return new[,] { { 2, 2 }, { 2, 2 } };
    }

    public List<int[]> GetMoves2(
        List<object> moveList,
        int[] pieceLocation,
        List<int[]> allPieceLocations,
        string[,] board
    )
    {
        foreach (var move in moveList)
        {
            var typecasted = (List<object>)move;
            var move_length = typecasted.Count;
            var move_type = typecasted[0].ToString();
            bool collision_type = (bool)typecasted[1];
            var attack_type = typecasted[2];
            List<int[]> moveLocations = new List<int[]>();

            string direction1 = "0";
            int direction1_int = 0;
            string direction2 = "0";
            int direction2_int = 0;
            int[] forLoopDir = new int[2];

            if (move_length == 5)
            {
                direction1 = typecasted[3].ToString();
                direction1_int = (int)typecasted[4];
                forLoopDir[0] = DirectionToForLoopInt(direction1);
            }
            else if (move_length == 6)
            {
                direction1 = typecasted[3].ToString();
                direction2 = typecasted[4].ToString();
                direction1_int = (int)typecasted[5];
                forLoopDir[0] = DirectionToForLoopInt(direction1);
                forLoopDir[1] = DirectionToForLoopInt(direction2);
            }
            else if (move_length == 7)
            {
                direction1 = typecasted[3].ToString();
                direction1_int = (int)typecasted[4];
                direction2 = typecasted[5].ToString();
                direction2_int = (int)typecasted[6];
                forLoopDir[0] = DirectionToForLoopInt(direction1);
                forLoopDir[1] = DirectionToForLoopInt(direction2);
            }

            if (move_type == "Path")
            {
                bool notInAllPieces = true;
                if (move_length == 5)
                {
                    var pieceLocIndex = 0;
                    var locationCopy = new int[] {pieceLocation[0], pieceLocation[1]};

                    if (direction1 == "UP" || direction1 == "DOWN") { pieceLocIndex = 1; }
                    else { pieceLocIndex = 0; }

                    for (int i = pieceLocation[pieceLocIndex]; i < pieceLocation[pieceLocIndex] + direction1_int;)
                    {
                        i += forLoopDir[0];
                        if (i > board.GetLength(pieceLocIndex) || i < 0){ break; }
                        locationCopy[pieceLocIndex] = i;

                        foreach (var locationTaken in allPieceLocations)
                        {
                            if (locationTaken[0] == locationCopy[0] || locationTaken[1] == locationCopy[1]) { notInAllPieces = false; break; }
                        }
                        if (notInAllPieces) { moveLocations.Add(new int[]{locationCopy[0], locationCopy[1]}); }
                    }
                }

                else if (move_length == 6) { }
                else if (move_length == 7) { }
            }
            else if (move_type == "Direct")
            {
                if (move_length == 5) { }
                else if (move_length == 6) { }
                else if (move_length == 7) { }
            }
        }

        return new List<int[]> { };
    }

    public int DirectionToForLoopInt(string dir)
    {
        int intDir = 0;
        if (dir == "UP")
        {
            intDir = 1;
        }
        if (dir == "DOWN")
        {
            intDir = -1;
        }
        if (dir == "LEFT")
        {
            intDir = -1;
        }
        if (dir == "RIGHT")
        {
            intDir = 1;
        }
        return intDir;
    }

    public bool ValidateInput(
        string player_input,
        string[,] board,
        Dictionary<string, int[]> pieceList,
        List<int[]> allPieces
    )
    {
        var player_inputs = player_input.Split('x', ' ');
        var piece_name = player_inputs[0];
        var next_position = player_inputs[1];
        object? rough_movelist;
        bool piece_exists = false;

        //Checks if piece exists
        foreach (var piece in pieceList)
        {
            if (piece_name == piece.Key)
            {
                rough_movelist = bookOfWisdomParser(piece_name.Substring(0, piece_name.Length - 2));
                GetMoves((List<object>)rough_movelist, pieceList[piece_name], allPieces, board);
                GetMoves2((List<object>)rough_movelist, pieceList[piece_name], allPieces, board);
                piece_exists = true;

                break;
            }
        }

        var hehe = pieceList[piece_name];

        if (!piece_exists && !true)
        {
            return false;
        }

        return true;
    }

    public Tuple<string[,], bool> TakePlayerInput(
        string player1ID,
        string player2ID,
        string[,] board,
        int turn
    )
    {
        bool gameIsDone = false;
        bool moveIsCorrect = false;
        Dictionary<string, int[]> p1Pieces = new Dictionary<string, int[]>();
        Dictionary<string, int[]> p2Pieces = new Dictionary<string, int[]>();
        List<int[]> allPieces = new List<int[]>();

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != "0")
                {
                    var piece_values = board[i, j].Split('_', 2);
                    var player_name = piece_values[0];
                    var piece_name = piece_values[1];
                    if (player_name == player1ID)
                    {
                        p1Pieces.Add(piece_name, new int[] { i, j });
                        allPieces.Add(new int[] { i, j });
                    }
                    else if (player_name == player2ID)
                    {
                        p2Pieces.Add(piece_name, new int[] { i, j });
                        allPieces.Add(new int[] { i, j });
                    }
                }
            }
        }

        if ((turn % 2) == 1)
        {
            do
            {
                Console.Write("{0} its your turn, make a move: ", player1ID);
                var playerInput = Console.ReadLine();
                moveIsCorrect = ValidateInput(playerInput, board, p1Pieces, allPieces);
            } while (!moveIsCorrect);
        }
        else if ((turn % 2) == 0)
        {
            do
            {
                Console.Write("{0} its your turn, make a move: ", player2ID);
                var playerInput = Console.ReadLine();
                moveIsCorrect = ValidateInput(playerInput, board, p2Pieces, allPieces);
            } while (!moveIsCorrect);
        }

        return Tuple.Create(board, gameIsDone);
    }

    // STARTGAME / MAIN
    public override object? VisitStartGame(HessParser.StartGameContext context)
    {
        var player1ID = context.GetChild(1).GetText();
        var player2ID = context.GetChild(3).GetText();

        var player1 = bookOfWisdomParser(player1ID);
        var player2 = bookOfWisdomParser(player2ID);

        var boardPosition = boardPosToValue(bookOfWisdomParser("BOARD")?.ToString());

        string[,] board = new string[boardPosition[0], boardPosition[1]];

        for (int i = 0; i < boardPosition[0]; i++)
        {
            for (int j = 0; j < boardPosition[1]; j++)
            {
                board[i, j] = "0";
            }
        }

        player1 = PlaceListUpdate(player1);
        player2 = PlaceListUpdate(player2);

        board = PlacePieces(board, player1, player1ID);
        board = PlacePieces(board, player2, player2ID);

        PrintBoard(board);
        bool gameDone = false;
        int turn = 1;
        while (!gameDone)
        {
            TakePlayerInput(player1ID, player2ID, board, turn);
            turn++;
        }

        /*ValueTask = 0

        if = 0%
        xd = "player1id"
        if = 1
        player 2id

        valuetask +1
        bool gameDone = false;
        while(!gameDone) {
            take_input
            validate_input
                in check
                updateboard
            printboard
            
            take_input
                validate_input
                in check
                updateboard
            printboard

                for i
                    playerinput(string[i])
                    printboard
                


        }*/

        return null;
    }
}
