module Evaluator

open AST
open SixLabors.ImageSharp
open SixLabors.ImageSharp.Processing
open SixLabors.ImageSharp.PixelFormats

let load(path: string) : Image =
    Image.Load path

let save(path: string)(image: Image) : unit =
    image.Save path |> ignore

let compositeImages(img1: Image)(img2: Image): Image =
    let result = img1.Clone(fun x -> x |> ignore)
    result.Mutate(fun x -> x.DrawImage(img2, new GraphicsOptions
    (AlphaCompositionMode = PixelAlphaCompositionMode.SrcOver)) |> ignore)
    result


let evalEmotion(e: Emotion): string =
    "drawings/" + (e |> string) + ".PNG"

let evalAnimal(a: Animal): string =
    "drawings/" + (a.color |> string) + "_" + (a.animal |> string) + ".PNG"

let evalShoes(s: Shoes): string =
    match s.shoes with
    | ShoesBlank -> "drawings/Blank.PNG"
    | _ -> "drawings/" + (s.color |> string) + "_" + (s.shoes |> string) + ".PNG"

let evalAccessory(a: Accessory): string =
    match a.accessory with
    | AccessoryBlank -> "drawings/Blank.PNG"
    | _ -> "drawings/" + (a.color |> string) + "_" + (a.accessory |> string) + ".PNG"

let evalTop(t: Top): string =
    match t.top with
    | TopBlank -> "drawings/Blank.PNG"
    | _ -> "drawings/" + (t.color |> string) + "_" + (t.top |> string) + ".PNG"

let evalBottom(b: Bottom): string =
    match b.bottom with
    | BottomBlank -> "drawings/Blank.PNG"
    | _ -> "drawings/" + (b.color |> string) + "_" + (b.bottom |> string) + ".PNG"