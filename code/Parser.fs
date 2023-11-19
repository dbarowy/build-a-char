module Parser

open Combinator
open AST

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
    (pstr "grey" |>> (fun _ -> Grey))

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

let panimal =
    pseq
        (pleft pcolor pws1)
        (panimalnocolor)
        (fun(x,y) -> Animal(x,y))

let pshoes =
    pseq
        (pleft pcolor pws1)
        (pshoesnocolor)
        (fun(x,y) -> Shoes(x,y))

let paccessory =
    pseq
        (pleft pcolor pws1)
        (paccessorynocolor)
        (fun(x,y) -> Accessory(x,y))

//let poutfit =

//let ptop =

//let pbottom =

//let pexpr =
//    pseq
//        (pseq
//            (pseq
//                (pseq
//
//                )
//            )
//        )