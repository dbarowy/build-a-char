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

type Animal = { color: Color; animal: AnimalNoColor }

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

type Top = { color: Color; top: TopNoColor }

type BottomNoColor =
| Pants
| Shorts
| Skirt
| Unit

type Bottom = { color: Color; bottom: BottomNoColor }

type Outfit = { outfitTop: Top; outfitBottom: Bottom }

type ShoesNoColor =
| Sneakers
| CowboyBoots
| CombatBoots
| Heels
| Slippers

type Shoes = { color: Color; shoes: ShoesNoColor }

type AccessoryNoColor =
| Flower
| Star
| Glasses
| Sunglasses
| Scarf
| Gloves

type Accessory = { color: Color; accessory: AccessoryNoColor }

type Expr = Emotion * Animal * Outfit * Shoes * Accessory