module AST

type Color =
| Red
| Orange
| Yellow
| Green
| Blue
| Purple
| Pink
| Black
| White
| Grey

type AnimalNoColor =
| Bunny
| Cat
| Frog
| Bear

type Animal = Color * AnimalNoColor

type Emotion =
| Happy
| Neutral
| Sad
| Mad
| Tired

type TopNoColor =
| Shirt
| Sweater
| Hoodie
| Suit
| Dress

type Top = Color * TopNoColor

type BottomNoColor =
| Pants
| Shorts
| Skirt
| Unit

type Bottom = Color * BottomNoColor

type Outfit = Top * Bottom

type ShoesNoColor =
| Sneakers
| CowboyBoots
| CombatBoots
| Heels
| Slippers

type Shoes = Color * ShoesNoColor

type AccessoryNoColor =
| Flower
| Star
| Glasses
| Sunglasses
| Scarf
| Gloves

type Accessory = Color * AccessoryNoColor

type Expr = Emotion * Animal * Outfit * Shoes * Accessory