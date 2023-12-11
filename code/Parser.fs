module Parser

open Combinator
open AST
open System

let pcolor =
    (pstr "red" |>> (fun _ -> Red)) <|>
    (pstr "green" |>> (fun _ -> Green)) <|>
    (pstr "blue" |>> (fun _ -> Blue)) <|>
    (pstr "purple" |>> (fun _ -> Purple)) <|>
    (pstr "orange" |>> (fun _ -> Orange)) <|>
    (pstr "yellow" |>> (fun _ -> Yellow)) <|>
    (pstr "pink" |>> (fun _ -> Pink)) <|>
    (pstr "black" |>> (fun _ -> Black)) <|>
    (pstr "white" |>> (fun _ -> White)) <|>
    (pstr "brown" |>> (fun _ -> Brown))

let pemotion =
    (pstr "happy" |>> (fun _ -> Happy)) <|>
    (pstr "neutral" |>> (fun _ -> Neutral)) <|>
    (pstr "sad" |>> (fun _ -> Sad)) <|>
    (pstr "mad" |>> (fun _ -> Mad)) <|>
    (pstr "tired" |>> (fun _ -> Tired))

let pshoesnocolor =
    (pstr "sneakers" |>> (fun _ -> Sneakers)) <|>
    (pstr "cowboy boots" |>> (fun _ -> CowboyBoots)) <|>
    (pstr "combat boots" |>> (fun _ -> CombatBoots)) <|>
    (pstr "heels" |>> (fun _ -> Heels)) <|>
    (pstr "slippers" |>> (fun _ -> Slippers))

let paccessorynocolor =
    (pstr "flower" |>> (fun _ -> Flower)) <|>
    (pstr "star" |>> (fun _ -> Star)) <|>
    (pstr "glasses" |>> (fun _ -> Glasses)) <|>
    (pstr "sunglasses" |>> (fun _ -> Sunglasses)) <|>
    (pstr "scarf" |>> (fun _ -> Scarf)) <|>
    (pstr "gloves" |>> (fun _ -> Gloves))

let panimalnocolor =
    (pstr "bunny" |>> (fun _ -> Bunny)) <|>
    (pstr "cat" |>> (fun _ -> Cat)) <|>
    (pstr "frog" |>> (fun _ -> Frog)) <|>
    (pstr "bear" |>> (fun _ -> Bear))

let ptopnocolor =
    (pstr "tshirt" |>> (fun _ -> Tshirt)) <|>
    (pstr "sweater" |>> (fun _ -> Sweater)) <|>
    (pstr "hoodie" |>> (fun _ -> Hoodie)) <|>
    (pstr "suit" |>> (fun _ -> Suit)) <|>
    (pstr "dress" |>> (fun _ -> Dress))

let pbottomnocolor =
    (pstr "pants" |>> (fun _ -> Pants)) <|>
    (pstr "shorts" |>> (fun _ -> Shorts)) <|>
    (pstr "skirt" |>> (fun _ -> Skirt)) <|>
    (pstr "blank" |>> (fun _ -> Blank))


let panimal =
    pseq
        (pleft pcolor pws1)
        (panimalnocolor)
        (fun(x,y) -> { color = x; animal = y })

let pshoes =
    pseq
        (pleft pcolor pws1)
        (pshoesnocolor)
        (fun(x,y) -> { color = x; shoes = y })

let paccessory =
    pseq
        (pleft pcolor pws1)
        (paccessorynocolor)
        (fun(x,y) -> { color = x; accessory = y })

let ptop =
    pseq
        (pleft pcolor pws1)
        (ptopnocolor)
        (fun(x,y) -> { color = x; top = y })

let pbottom =
    pseq
        (pleft pcolor pws1)
        (pbottomnocolor)
        (fun(x,y) -> { color = x; bottom = y })

let pexpr =
    pseq
        (pseq
            (pseq
                (pseq
                    (pseq
                        (pleft pemotion pws1)
                        (pleft panimal pws1)
                        (fun((x, y)) -> { emotion = x; animal = y; top = {color = Black; top = Tshirt};
                            bottom = {color = Black; bottom = Blank}; shoes = {color = Black; shoes = Sneakers};
                            accessory = {color = Black; accessory = Scarf} })
                    )
                    (pleft ptop pws1)
                    (fun(x, y) -> { x with top = y })
                )
                (pleft pbottom pws1)
                (fun(x, y) -> { x with bottom = y })
            )
            (pleft pshoes pws1)
            (fun(x, y) -> { x with shoes = y })
        )
        (paccessory)
        (fun(x, y) -> { x with accessory = y })

let grammar = pleft pexpr peof

let parse (input: string) : Expr option =
    let i = prepare input
    match grammar i with
    | Success(ast, _) -> Some ast
    | Failure(_,_) -> None