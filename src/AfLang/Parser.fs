// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "Parser.fsy"

open Lang.Ast

let helper x = x * x

# 12 "Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | NEWLINE
  | EQUALS
  | LET
  | MINUS
  | PLUS
  | SLASH
  | STAR
  | RIGHT_PAREN
  | LEFT_PAREN
  | IDENT of (string)
  | INT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_NEWLINE
    | TOKEN_EQUALS
    | TOKEN_LET
    | TOKEN_MINUS
    | TOKEN_PLUS
    | TOKEN_SLASH
    | TOKEN_STAR
    | TOKEN_RIGHT_PAREN
    | TOKEN_LEFT_PAREN
    | TOKEN_IDENT
    | TOKEN_INT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_prog
    | NONTERM_exprs
    | NONTERM_expr

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | NEWLINE  -> 1 
  | EQUALS  -> 2 
  | LET  -> 3 
  | MINUS  -> 4 
  | PLUS  -> 5 
  | SLASH  -> 6 
  | STAR  -> 7 
  | RIGHT_PAREN  -> 8 
  | LEFT_PAREN  -> 9 
  | IDENT _ -> 10 
  | INT _ -> 11 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_NEWLINE 
  | 2 -> TOKEN_EQUALS 
  | 3 -> TOKEN_LET 
  | 4 -> TOKEN_MINUS 
  | 5 -> TOKEN_PLUS 
  | 6 -> TOKEN_SLASH 
  | 7 -> TOKEN_STAR 
  | 8 -> TOKEN_RIGHT_PAREN 
  | 9 -> TOKEN_LEFT_PAREN 
  | 10 -> TOKEN_IDENT 
  | 11 -> TOKEN_INT 
  | 14 -> TOKEN_end_of_input
  | 12 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_prog 
    | 3 -> NONTERM_prog 
    | 4 -> NONTERM_exprs 
    | 5 -> NONTERM_exprs 
    | 6 -> NONTERM_expr 
    | 7 -> NONTERM_expr 
    | 8 -> NONTERM_expr 
    | 9 -> NONTERM_expr 
    | 10 -> NONTERM_expr 
    | 11 -> NONTERM_expr 
    | 12 -> NONTERM_expr 
    | 13 -> NONTERM_expr 
    | 14 -> NONTERM_expr 
    | 15 -> NONTERM_expr 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 14 
let _fsyacc_tagOfErrorTerminal = 12

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | NEWLINE  -> "NEWLINE" 
  | EQUALS  -> "EQUALS" 
  | LET  -> "LET" 
  | MINUS  -> "MINUS" 
  | PLUS  -> "PLUS" 
  | SLASH  -> "SLASH" 
  | STAR  -> "STAR" 
  | RIGHT_PAREN  -> "RIGHT_PAREN" 
  | LEFT_PAREN  -> "LEFT_PAREN" 
  | IDENT _ -> "IDENT" 
  | INT _ -> "INT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | NEWLINE  -> (null : System.Object) 
  | EQUALS  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | SLASH  -> (null : System.Object) 
  | STAR  -> (null : System.Object) 
  | RIGHT_PAREN  -> (null : System.Object) 
  | LEFT_PAREN  -> (null : System.Object) 
  | IDENT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;1us;65535us;0us;2us;1us;65535us;0us;4us;8us;65535us;0us;7us;4us;6us;10us;11us;16us;17us;23us;19us;24us;20us;25us;21us;26us;22us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;5us;7us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;1us;1us;1us;2us;2us;3us;4us;1us;3us;5us;4us;12us;13us;14us;15us;5us;5us;12us;13us;14us;15us;2us;6us;7us;2us;6us;7us;2us;6us;7us;6us;6us;7us;12us;13us;14us;15us;1us;7us;1us;8us;2us;9us;10us;1us;10us;1us;11us;5us;11us;12us;13us;14us;15us;1us;11us;5us;12us;12us;13us;14us;15us;5us;12us;13us;13us;14us;15us;5us;12us;13us;14us;14us;15us;5us;12us;13us;14us;15us;15us;1us;12us;1us;13us;1us;14us;1us;15us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;6us;8us;11us;13us;19us;25us;28us;31us;34us;41us;43us;45us;48us;50us;52us;58us;60us;66us;72us;78us;84us;86us;88us;90us;|]
let _fsyacc_action_rows = 27
let _fsyacc_actionTableElements = [|5us;32768us;0us;3us;3us;8us;9us;16us;10us;14us;11us;13us;0us;49152us;0us;16385us;0us;16386us;5us;32768us;0us;5us;3us;8us;9us;16us;10us;14us;11us;13us;0us;16387us;4us;16388us;4us;24us;5us;23us;6us;26us;7us;25us;4us;16389us;4us;24us;5us;23us;6us;26us;7us;25us;1us;32768us;10us;9us;1us;32768us;2us;10us;4us;32768us;3us;8us;9us;16us;10us;14us;11us;13us;5us;16390us;1us;12us;4us;24us;5us;23us;6us;26us;7us;25us;0us;16391us;0us;16392us;1us;16393us;1us;15us;0us;16394us;4us;32768us;3us;8us;9us;16us;10us;14us;11us;13us;5us;32768us;4us;24us;5us;23us;6us;26us;7us;25us;8us;18us;0us;16395us;2us;16396us;6us;26us;7us;25us;2us;16397us;6us;26us;7us;25us;0us;16398us;0us;16399us;4us;32768us;3us;8us;9us;16us;10us;14us;11us;13us;4us;32768us;3us;8us;9us;16us;10us;14us;11us;13us;4us;32768us;3us;8us;9us;16us;10us;14us;11us;13us;4us;32768us;3us;8us;9us;16us;10us;14us;11us;13us;|]
let _fsyacc_actionTableRowOffsets = [|0us;6us;7us;8us;9us;15us;16us;21us;26us;28us;30us;35us;41us;42us;43us;45us;46us;51us;57us;58us;61us;64us;65us;66us;71us;76us;81us;|]
let _fsyacc_reductionSymbolCounts = [|1us;1us;1us;2us;2us;1us;4us;5us;1us;1us;2us;3us;3us;3us;3us;3us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;3us;3us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;|]
let _fsyacc_immediateActions = [|65535us;49152us;16385us;16386us;65535us;16387us;65535us;65535us;65535us;65535us;65535us;65535us;16391us;16392us;65535us;16394us;65535us;65535us;16395us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|]
let _fsyacc_reductions = lazy [|
# 152 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Expr option in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startstart));
# 161 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_prog in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "Parser.fsy"
                                   _1 
                   )
# 35 "Parser.fsy"
                 : Expr option));
# 172 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "Parser.fsy"
                               None 
                   )
# 38 "Parser.fsy"
                 : 'gentype_prog));
# 182 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_exprs in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "Parser.fsy"
                                     Some (Expr.Decls (List.rev _1)) 
                   )
# 39 "Parser.fsy"
                 : 'gentype_prog));
# 193 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_exprs in
            let _2 = parseState.GetInput(2) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "Parser.fsy"
                                      _2 :: _1 
                   )
# 42 "Parser.fsy"
                 : 'gentype_exprs));
# 205 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "Parser.fsy"
                                [ _1 ] 
                   )
# 43 "Parser.fsy"
                 : 'gentype_exprs));
# 216 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "Parser.fsy"
                                                 Decl (_2, _4)
                   )
# 46 "Parser.fsy"
                 : 'gentype_expr));
# 228 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "Parser.fsy"
                                                         Decl (_2, _4)
                   )
# 47 "Parser.fsy"
                 : 'gentype_expr));
# 240 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "Parser.fsy"
                               Int _1 
                   )
# 48 "Parser.fsy"
                 : 'gentype_expr));
# 251 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "Parser.fsy"
                                 Ident _1 
                   )
# 49 "Parser.fsy"
                 : 'gentype_expr));
# 262 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "Parser.fsy"
                                         Ident _1 
                   )
# 50 "Parser.fsy"
                 : 'gentype_expr));
# 273 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "Parser.fsy"
                                                       Paren _2 
                   )
# 51 "Parser.fsy"
                 : 'gentype_expr));
# 284 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "Parser.fsy"
                                           InfixApp (_1, Operator.AddOp, _3) 
                   )
# 52 "Parser.fsy"
                 : 'gentype_expr));
# 296 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "Parser.fsy"
                                           InfixApp (_1, Operator.SubOp, _3) 
                   )
# 53 "Parser.fsy"
                 : 'gentype_expr));
# 308 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "Parser.fsy"
                                           InfixApp (_1, Operator.MulOp, _3) 
                   )
# 54 "Parser.fsy"
                 : 'gentype_expr));
# 320 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "Parser.fsy"
                                           InfixApp (_1, Operator.DivOp, _3) 
                   )
# 55 "Parser.fsy"
                 : 'gentype_expr));
|]
# 333 "Parser.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions = _fsyacc_reductions.Value;
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 15;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let start lexer lexbuf : Expr option =
    engine lexer lexbuf 0 :?> _
