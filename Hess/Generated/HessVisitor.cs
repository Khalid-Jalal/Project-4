//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Hess.g4 by ANTLR 4.12.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="HessParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public interface IHessVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] HessParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLine([NotNull] HessParser.LineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] HessParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.defineBoard"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefineBoard([NotNull] HessParser.DefineBoardContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.startGame"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStartGame([NotNull] HessParser.StartGameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] HessParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] HessParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] HessParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.moveList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMoveList([NotNull] HessParser.MoveListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.move"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMove([NotNull] HessParser.MoveContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.moveExtra"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMoveExtra([NotNull] HessParser.MoveExtraContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstant([NotNull] HessParser.ConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.player"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlayer([NotNull] HessParser.PlayerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.place"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlace([NotNull] HessParser.PlaceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.boardpositionlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoardpositionlist([NotNull] HessParser.BoardpositionlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.collision"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCollision([NotNull] HessParser.CollisionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.attacktype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttacktype([NotNull] HessParser.AttacktypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.direction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDirection([NotNull] HessParser.DirectionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HessParser.movetype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMovetype([NotNull] HessParser.MovetypeContext context);
}
