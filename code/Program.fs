open Parser
open Evaluator
open System.IO

let rec repl() : unit =
    let input = System.Console.ReadLine()
    if input = "quit" then
        printfn "Goodbye!"
        exit 0
    else
        let asto = parse input
        match asto with
        | Some ast -> 
            let animalOne = load (evalAnimal ast.animal)
            let emotionOne = load (evalEmotion ast.emotion)
            let withEmotion = compositeImages animalOne emotionOne
            let bottomOne = load (evalBottom ast.bottom)
            let withBottom = compositeImages withEmotion bottomOne
            let shoesOne = load (evalShoes ast.shoes)
            let withShoes = compositeImages withBottom shoesOne
            let topOne = load (evalTop ast.top)
            let withTop = compositeImages withShoes topOne
            let accessoryOne = load (evalAccessory ast.accessory)
            (compositeImages withTop accessoryOne) |> save "Character.PNG"
        | None -> printf "Make sure your input is of the form <emotion> <animal> wearing <outfit> <shoes> and <accessory>\n"
    repl()

[<EntryPoint>]
let main args =
    printf "-----------------------------------------------------------------------------------------------------------------\n" 
    printf "-----------------------------------------------------------------------------------------------------------------\n" 
    printf " \n Hello! Welcome to Jess and Will's character generator! :D \n
    -------------------------------------------------------------------------------------------\n
    This character generator will accept prompts that look like this: \n
    <emotion> <animal> wearing <outfit> <shoes> and <accessory> \n
    and it will return a PNG of a custom character fitting that description!\n
    -------------------------------------------------------------------------------------------\n
    Here are the available options for each category:\n
    <emotion>: happy, neutral, sad, mad, or tired\n
    <animal>: <color> bunny, cat, frog, or bear\n
    <outfit>: <color> <top> and <bottom> OR <color> suit OR <color> dress\n
    <top>: <color> shirt, sweater, or hoodie\n
    <bottom>: <color> pants, shorts, or skirt\n
    <shoes>: <color> sneakers, cowboy boots, combat boots, heels, or slippers \n
    <accessory>: <color> flower, star, glasses, sunglasses, scarf, or gloves\n
    <color>: red, orange, yellow, green, blue, purple, pink, white, black, or brown\n
    -------------------------------------------------------------------------------------------\n
    Here are some example prompts:\n
    happy white bunny wearing green shirt and blue pants yellow sneakers and pink flower\n 
    
    neutral orange cat wearing purple dress blue cowboy boots and yellow star\n

    tired green frog wearing red sweater orange shorts piink slippers and blue sunglasses\n \n"
    printf "-----------------------------------------------------------------------------------------------------------------\n"
    printf "-----------------------------------------------------------------------------------------------------------------\n" 
    printf "Please enter a prompt!\n"
    repl()
    0