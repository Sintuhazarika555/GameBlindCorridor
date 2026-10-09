 # <img src="https://raw.githubusercontent.com/Sintuhazarika555/GameBlindCorridor/refs/heads/main/logonew.png" alt="HeroScene Main Menu" width="10%"/> Blind Corridor: A 2D Atmospheric Maze-Runner
 



**Blind Corridor** is an atmospheric top-down 2D maze-runner developed using **Unity 6** and **C#** under the **Universal Render Pipeline (URP 2D)**. Designed with a portrait-first 9:16 aspect ratio ($1080 \times 1920$), the game challenges players to navigate pitch-black corridors where visibility is strictly limited to an attached torchlight source .

---

##  Screenshots

<p align="center">
  <img src="https://raw.githubusercontent.com/Sintuhazarika555/GameBlindCorridor/refs/heads/main/Screenshot%20(24).png" alt="HeroScene Main Menu" width="45%"/>
  
  <img src="https://raw.githubusercontent.com/Sintuhazarika555/GameBlindCorridor/refs/heads/main/Screenshot%20(25).png" alt="GameScene Gameplay" width="45%"/>
</p>

`HeroScene` — Main Menu Interface with Start Trigger  
`GameScene` — 2D Torch Light Masking, Dynamic Hazards, and HUD Overlay  

---

## Key Features

- **Dynamic 2D Torch Lighting:** Utilizes URP 2D Point Light components to create localized visibility and ambient darkness masking.
- **Zero-Clutter Gesture Controls:** Implements an invisible full-screen touch listener using Unity `EventSystem` interfaces (`IPointerDownHandler`, `IDragHandler`, `IPointerUpHandler`) for clutter-free mobile navigation.
- **Dual Platform Input:** Smooth 360-degree mobile touch drag paired with WASD / Arrow key fallbacks for PC testing.
- **Session Best Score System:** Real-time run timing (`MM:SS`) using `Time.deltaTime` and automatic personal best score comparison saved via `PlayerPrefs`.
- **Cross-Platform Deployment:** Configured for standalone desktop execution (**Windows `.exe`**) and web distribution (**WebGL**).

---

## Tech Stack & Architecture

- **Game Engine:** Unity 6 (6000.5.4f1)
- **Render Pipeline:** Universal Render Pipeline (URP 2D)
- **Scripting Language:** C# (.NET)
- **UI Framework:** TextMeshPro & Canvas UI Engine
- **Physics Engine:** Rigidbody2D & Collider2D
- **Target Resolution:** 1080 × 1920 (9:16 Portrait Aspect Ratio)

---

## PC Controls
* **WASD / Arrow Keys:** Navigate the ghost character
* **ESC:** Return to main menu (`HeroScene`)
---


