// Generated from c:\Users\10hi\Desktop\Hess\Hess.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class HessParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, BOARDPOSITION=21, IDENTIFIER=22, NATURAL_NUMBER=23, 
		STRING=24, LETTER=25, BOOL=26, NULL=27, WS=28;
	public static final int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_defineBoard = 3, 
		RULE_startGame = 4, RULE_assignment = 5, RULE_expression = 6, RULE_block = 7, 
		RULE_moveList = 8, RULE_move = 9, RULE_moveExtra = 10, RULE_constant = 11, 
		RULE_player = 12, RULE_place = 13, RULE_boardpositionlist = 14, RULE_collision = 15, 
		RULE_attacktype = 16, RULE_direction = 17, RULE_movetype = 18;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "line", "statement", "defineBoard", "startGame", "assignment", 
			"expression", "block", "moveList", "move", "moveExtra", "constant", "player", 
			"place", "boardpositionlist", "collision", "attacktype", "direction", 
			"movetype"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "';'", "'BOARD'", "'='", "'('", "')'", "'STARTGAME('", "','", "'{'", 
			"'}'", "'true'", "'false'", "'ATTACK'", "'MOVE'", "'ATKMOVE'", "'UP'", 
			"'LEFT'", "'RIGHT'", "'DOWN'", "'Direct'", "'Path'", null, null, null, 
			null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, "BOARDPOSITION", 
			"IDENTIFIER", "NATURAL_NUMBER", "STRING", "LETTER", "BOOL", "NULL", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Hess.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public HessParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public DefineBoardContext defineBoard() {
			return getRuleContext(DefineBoardContext.class,0);
		}
		public StartGameContext startGame() {
			return getRuleContext(StartGameContext.class,0);
		}
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(38);
			defineBoard();
			setState(42);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==IDENTIFIER) {
				{
				{
				setState(39);
				line();
				}
				}
				setState(44);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(45);
			startGame();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LineContext extends ParserRuleContext {
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public LineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_line; }
	}

	public final LineContext line() throws RecognitionException {
		LineContext _localctx = new LineContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_line);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(47);
			statement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(49);
			assignment();
			}
			setState(50);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DefineBoardContext extends ParserRuleContext {
		public TerminalNode BOARDPOSITION() { return getToken(HessParser.BOARDPOSITION, 0); }
		public DefineBoardContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_defineBoard; }
	}

	public final DefineBoardContext defineBoard() throws RecognitionException {
		DefineBoardContext _localctx = new DefineBoardContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_defineBoard);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(52);
			match(T__1);
			setState(53);
			match(T__2);
			setState(54);
			match(T__3);
			setState(55);
			match(BOARDPOSITION);
			setState(56);
			match(T__4);
			setState(57);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StartGameContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(HessParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(HessParser.IDENTIFIER, i);
		}
		public StartGameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_startGame; }
	}

	public final StartGameContext startGame() throws RecognitionException {
		StartGameContext _localctx = new StartGameContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_startGame);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(59);
			match(T__5);
			setState(60);
			match(IDENTIFIER);
			setState(65);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__6) {
				{
				{
				setState(61);
				match(T__6);
				setState(62);
				match(IDENTIFIER);
				}
				}
				setState(67);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(68);
			match(T__4);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(HessParser.IDENTIFIER, 0); }
		public MoveListContext moveList() {
			return getRuleContext(MoveListContext.class,0);
		}
		public PlayerContext player() {
			return getRuleContext(PlayerContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_assignment);
		try {
			setState(82);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(70);
				match(IDENTIFIER);
				setState(71);
				match(T__2);
				setState(72);
				match(T__7);
				setState(73);
				moveList();
				setState(74);
				match(T__8);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(76);
				match(IDENTIFIER);
				setState(77);
				match(T__2);
				setState(78);
				player();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(79);
				match(IDENTIFIER);
				setState(80);
				match(T__2);
				setState(81);
				expression();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public TerminalNode IDENTIFIER() { return getToken(HessParser.IDENTIFIER, 0); }
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	}

	public final ExpressionContext expression() throws RecognitionException {
		ExpressionContext _localctx = new ExpressionContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_expression);
		try {
			setState(86);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NATURAL_NUMBER:
			case STRING:
			case BOOL:
			case NULL:
				enterOuterAlt(_localctx, 1);
				{
				setState(84);
				constant();
				}
				break;
			case IDENTIFIER:
				enterOuterAlt(_localctx, 2);
				{
				setState(85);
				match(IDENTIFIER);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BlockContext extends ParserRuleContext {
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(88);
			match(T__7);
			setState(92);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==IDENTIFIER) {
				{
				{
				setState(89);
				line();
				}
				}
				setState(94);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(95);
			match(T__8);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MoveListContext extends ParserRuleContext {
		public List<MoveContext> move() {
			return getRuleContexts(MoveContext.class);
		}
		public MoveContext move(int i) {
			return getRuleContext(MoveContext.class,i);
		}
		public MoveListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_moveList; }
	}

	public final MoveListContext moveList() throws RecognitionException {
		MoveListContext _localctx = new MoveListContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_moveList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(97);
			move();
			setState(102);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__6) {
				{
				{
				setState(98);
				match(T__6);
				setState(99);
				move();
				}
				}
				setState(104);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MoveContext extends ParserRuleContext {
		public MovetypeContext movetype() {
			return getRuleContext(MovetypeContext.class,0);
		}
		public CollisionContext collision() {
			return getRuleContext(CollisionContext.class,0);
		}
		public AttacktypeContext attacktype() {
			return getRuleContext(AttacktypeContext.class,0);
		}
		public DirectionContext direction() {
			return getRuleContext(DirectionContext.class,0);
		}
		public MoveExtraContext moveExtra() {
			return getRuleContext(MoveExtraContext.class,0);
		}
		public MoveContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_move; }
	}

	public final MoveContext move() throws RecognitionException {
		MoveContext _localctx = new MoveContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_move);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(105);
			movetype();
			setState(106);
			collision();
			setState(107);
			attacktype();
			setState(108);
			direction();
			setState(109);
			moveExtra();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MoveExtraContext extends ParserRuleContext {
		public List<TerminalNode> NATURAL_NUMBER() { return getTokens(HessParser.NATURAL_NUMBER); }
		public TerminalNode NATURAL_NUMBER(int i) {
			return getToken(HessParser.NATURAL_NUMBER, i);
		}
		public DirectionContext direction() {
			return getRuleContext(DirectionContext.class,0);
		}
		public MoveExtraContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_moveExtra; }
	}

	public final MoveExtraContext moveExtra() throws RecognitionException {
		MoveExtraContext _localctx = new MoveExtraContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_moveExtra);
		try {
			setState(119);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(111);
				match(NATURAL_NUMBER);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(112);
				match(NATURAL_NUMBER);
				setState(113);
				direction();
				setState(114);
				match(NATURAL_NUMBER);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(116);
				direction();
				setState(117);
				match(NATURAL_NUMBER);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode NATURAL_NUMBER() { return getToken(HessParser.NATURAL_NUMBER, 0); }
		public TerminalNode STRING() { return getToken(HessParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(HessParser.BOOL, 0); }
		public TerminalNode NULL() { return getToken(HessParser.NULL, 0); }
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(121);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NATURAL_NUMBER) | (1L << STRING) | (1L << BOOL) | (1L << NULL))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PlayerContext extends ParserRuleContext {
		public List<PlaceContext> place() {
			return getRuleContexts(PlaceContext.class);
		}
		public PlaceContext place(int i) {
			return getRuleContext(PlaceContext.class,i);
		}
		public PlayerContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_player; }
	}

	public final PlayerContext player() throws RecognitionException {
		PlayerContext _localctx = new PlayerContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_player);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(123);
			match(T__7);
			setState(124);
			place();
			setState(129);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__6) {
				{
				{
				setState(125);
				match(T__6);
				setState(126);
				place();
				}
				}
				setState(131);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(132);
			match(T__8);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PlaceContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(HessParser.IDENTIFIER, 0); }
		public BoardpositionlistContext boardpositionlist() {
			return getRuleContext(BoardpositionlistContext.class,0);
		}
		public PlaceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_place; }
	}

	public final PlaceContext place() throws RecognitionException {
		PlaceContext _localctx = new PlaceContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_place);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(134);
			match(IDENTIFIER);
			setState(135);
			match(T__6);
			setState(136);
			match(T__7);
			setState(137);
			boardpositionlist();
			setState(138);
			match(T__8);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BoardpositionlistContext extends ParserRuleContext {
		public List<TerminalNode> BOARDPOSITION() { return getTokens(HessParser.BOARDPOSITION); }
		public TerminalNode BOARDPOSITION(int i) {
			return getToken(HessParser.BOARDPOSITION, i);
		}
		public BoardpositionlistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boardpositionlist; }
	}

	public final BoardpositionlistContext boardpositionlist() throws RecognitionException {
		BoardpositionlistContext _localctx = new BoardpositionlistContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_boardpositionlist);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(140);
			match(BOARDPOSITION);
			setState(145);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__6) {
				{
				{
				setState(141);
				match(T__6);
				setState(142);
				match(BOARDPOSITION);
				}
				}
				setState(147);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CollisionContext extends ParserRuleContext {
		public CollisionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_collision; }
	}

	public final CollisionContext collision() throws RecognitionException {
		CollisionContext _localctx = new CollisionContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_collision);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(148);
			_la = _input.LA(1);
			if ( !(_la==T__9 || _la==T__10) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AttacktypeContext extends ParserRuleContext {
		public AttacktypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attacktype; }
	}

	public final AttacktypeContext attacktype() throws RecognitionException {
		AttacktypeContext _localctx = new AttacktypeContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_attacktype);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(150);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__11) | (1L << T__12) | (1L << T__13))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DirectionContext extends ParserRuleContext {
		public DirectionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_direction; }
	}

	public final DirectionContext direction() throws RecognitionException {
		DirectionContext _localctx = new DirectionContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_direction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(152);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__14) | (1L << T__15) | (1L << T__16) | (1L << T__17))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MovetypeContext extends ParserRuleContext {
		public MovetypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_movetype; }
	}

	public final MovetypeContext movetype() throws RecognitionException {
		MovetypeContext _localctx = new MovetypeContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_movetype);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(154);
			_la = _input.LA(1);
			if ( !(_la==T__18 || _la==T__19) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\36\u009f\4\2\t\2"+
		"\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\3\2\3\2\7\2+\n\2\f\2\16\2.\13\2\3\2\3\2\3\3\3\3\3"+
		"\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\7\6B\n\6\f\6\16"+
		"\6E\13\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\5\7U"+
		"\n\7\3\b\3\b\5\bY\n\b\3\t\3\t\7\t]\n\t\f\t\16\t`\13\t\3\t\3\t\3\n\3\n"+
		"\3\n\7\ng\n\n\f\n\16\nj\13\n\3\13\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f"+
		"\3\f\3\f\3\f\3\f\3\f\5\fz\n\f\3\r\3\r\3\16\3\16\3\16\3\16\7\16\u0082\n"+
		"\16\f\16\16\16\u0085\13\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\17\3\20"+
		"\3\20\3\20\7\20\u0092\n\20\f\20\16\20\u0095\13\20\3\21\3\21\3\22\3\22"+
		"\3\23\3\23\3\24\3\24\3\24\2\2\25\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36"+
		" \"$&\2\7\4\2\31\32\34\35\3\2\f\r\3\2\16\20\3\2\21\24\3\2\25\26\2\u0096"+
		"\2(\3\2\2\2\4\61\3\2\2\2\6\63\3\2\2\2\b\66\3\2\2\2\n=\3\2\2\2\fT\3\2\2"+
		"\2\16X\3\2\2\2\20Z\3\2\2\2\22c\3\2\2\2\24k\3\2\2\2\26y\3\2\2\2\30{\3\2"+
		"\2\2\32}\3\2\2\2\34\u0088\3\2\2\2\36\u008e\3\2\2\2 \u0096\3\2\2\2\"\u0098"+
		"\3\2\2\2$\u009a\3\2\2\2&\u009c\3\2\2\2(,\5\b\5\2)+\5\4\3\2*)\3\2\2\2+"+
		".\3\2\2\2,*\3\2\2\2,-\3\2\2\2-/\3\2\2\2.,\3\2\2\2/\60\5\n\6\2\60\3\3\2"+
		"\2\2\61\62\5\6\4\2\62\5\3\2\2\2\63\64\5\f\7\2\64\65\7\3\2\2\65\7\3\2\2"+
		"\2\66\67\7\4\2\2\678\7\5\2\289\7\6\2\29:\7\27\2\2:;\7\7\2\2;<\7\3\2\2"+
		"<\t\3\2\2\2=>\7\b\2\2>C\7\30\2\2?@\7\t\2\2@B\7\30\2\2A?\3\2\2\2BE\3\2"+
		"\2\2CA\3\2\2\2CD\3\2\2\2DF\3\2\2\2EC\3\2\2\2FG\7\7\2\2G\13\3\2\2\2HI\7"+
		"\30\2\2IJ\7\5\2\2JK\7\n\2\2KL\5\22\n\2LM\7\13\2\2MU\3\2\2\2NO\7\30\2\2"+
		"OP\7\5\2\2PU\5\32\16\2QR\7\30\2\2RS\7\5\2\2SU\5\16\b\2TH\3\2\2\2TN\3\2"+
		"\2\2TQ\3\2\2\2U\r\3\2\2\2VY\5\30\r\2WY\7\30\2\2XV\3\2\2\2XW\3\2\2\2Y\17"+
		"\3\2\2\2Z^\7\n\2\2[]\5\4\3\2\\[\3\2\2\2]`\3\2\2\2^\\\3\2\2\2^_\3\2\2\2"+
		"_a\3\2\2\2`^\3\2\2\2ab\7\13\2\2b\21\3\2\2\2ch\5\24\13\2de\7\t\2\2eg\5"+
		"\24\13\2fd\3\2\2\2gj\3\2\2\2hf\3\2\2\2hi\3\2\2\2i\23\3\2\2\2jh\3\2\2\2"+
		"kl\5&\24\2lm\5 \21\2mn\5\"\22\2no\5$\23\2op\5\26\f\2p\25\3\2\2\2qz\7\31"+
		"\2\2rs\7\31\2\2st\5$\23\2tu\7\31\2\2uz\3\2\2\2vw\5$\23\2wx\7\31\2\2xz"+
		"\3\2\2\2yq\3\2\2\2yr\3\2\2\2yv\3\2\2\2z\27\3\2\2\2{|\t\2\2\2|\31\3\2\2"+
		"\2}~\7\n\2\2~\u0083\5\34\17\2\177\u0080\7\t\2\2\u0080\u0082\5\34\17\2"+
		"\u0081\177\3\2\2\2\u0082\u0085\3\2\2\2\u0083\u0081\3\2\2\2\u0083\u0084"+
		"\3\2\2\2\u0084\u0086\3\2\2\2\u0085\u0083\3\2\2\2\u0086\u0087\7\13\2\2"+
		"\u0087\33\3\2\2\2\u0088\u0089\7\30\2\2\u0089\u008a\7\t\2\2\u008a\u008b"+
		"\7\n\2\2\u008b\u008c\5\36\20\2\u008c\u008d\7\13\2\2\u008d\35\3\2\2\2\u008e"+
		"\u0093\7\27\2\2\u008f\u0090\7\t\2\2\u0090\u0092\7\27\2\2\u0091\u008f\3"+
		"\2\2\2\u0092\u0095\3\2\2\2\u0093\u0091\3\2\2\2\u0093\u0094\3\2\2\2\u0094"+
		"\37\3\2\2\2\u0095\u0093\3\2\2\2\u0096\u0097\t\3\2\2\u0097!\3\2\2\2\u0098"+
		"\u0099\t\4\2\2\u0099#\3\2\2\2\u009a\u009b\t\5\2\2\u009b%\3\2\2\2\u009c"+
		"\u009d\t\6\2\2\u009d\'\3\2\2\2\13,CTX^hy\u0083\u0093";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}