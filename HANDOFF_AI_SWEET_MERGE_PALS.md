# Handoff para IA — Sweet Merge Pals

## 1. Objetivo

Este documento fornece o contexto necessário para uma IA compreender o projeto **Sweet Merge Pals** e ajudar a criar uma apresentação PowerPoint académica, técnica e profissional.

A IA deve distinguir entre:

- funcionalidades confirmadas no código atual;
- funcionalidades descritas na documentação histórica;
- funcionalidades preparadas, mas ainda não finalizadas;
- funcionalidades futuras.

Não apresentar como concluída uma funcionalidade que não esteja confirmada no código ou validada por testes.

---

## 2. Identificação do projeto

| Informação | Detalhes |
|---|---|
| Nome | Sweet Merge Pals |
| Desenvolvedor | João Pedro Guedes da Costa |
| Tipo | Projeto final de curso / estágio |
| Engine | Unity 6 |
| Versão Unity | `6000.0.67f1` |
| Linguagem | C# |
| Plataformas-alvo | Android e iOS |
| Modelo de negócio | Free-to-play mobile |
| Género | Puzzle casual híbrido Match-3/Merge |
| Tema | Doces, pastelaria e confeitaria |
| Estado | Protótipo avançado/comercialmente preparado |

O projeto foi desenvolvido como um jogo mobile casual inspirado em títulos como **Candy Crush Saga** e **Royal Match**, combinando progressão por níveis, vidas, moedas, boosters e compras.

---

## 3. Conceito do jogo

Sweet Merge Pals é um jogo mobile baseado numa grelha de peças coloridas.

O jogador deve:

1. interagir com peças da grelha;
2. formar combinações de três ou mais elementos;
3. destruir as peças combinadas;
4. permitir que novas peças preencham os espaços;
5. cumprir os objetivos do nível;
6. obter pontuação e estrelas;
7. desbloquear novos níveis.

O jogo combina:

- mecânicas Match-3;
- boosters;
- obstáculos;
- objetivos variados;
- níveis limitados por movimentos ou tempo;
- sistema de vidas;
- moedas;
- recompensas;
- compras dentro da aplicação;
- anúncios recompensados;
- mapa de progressão.

A experiência pretendida é casual, relaxante e visualmente recompensadora, com efeitos sonoros, partículas, animações e feedback audiovisual forte.

---

## 4. Game Design — modelo MDA

O projeto foi pensado com base no modelo **MDA — Mechanics, Dynamics and Aesthetics**.

### Mechanics — Mecânicas

- Interação com peças numa grelha.
- Formação de combinações.
- Destruição de grupos de peças.
- Queda e reposicionamento de peças.
- Criação e utilização de boosters.
- Cumprimento de objetivos.
- Limitação por movimentos ou tempo.
- Sistema de pontuação e estrelas.
- Gestão de vidas e moedas.
- Progressão entre níveis.

### Dynamics — Dinâmicas

- Aumento gradual da dificuldade.
- Planeamento das jogadas.
- Gestão limitada de movimentos.
- Uso estratégico de boosters.
- Procura por combinações maiores.
- Ciclo jogar, ganhar/perder e melhorar.
- Progressão visual através de um mapa.
- Incentivo à utilização de moedas e recompensas.

### Aesthetics — Experiência

A experiência pretendida é:

- casual;
- relaxante;
- colorida;
- acessível;
- visualmente agradável;
- recompensadora;
- orientada para progressão e conquista.

A estética utiliza uma temática de confeitaria, com doces, cores vivas, personagens, partículas, brilhos, animações e sons de recompensa.

---

## 5. Estrutura técnica

Estrutura principal:

```text
Assets/
├── PuzzleMatchKit/
│   ├── Scripts/
│   ├── Scenes/
│   ├── Prefabs/
│   ├── Resources/
│   ├── Animations/
│   ├── Materials/
│   ├── Sounds/
│   ├── Fonts/
│   └── SpriteAtlases/
├── LevelPlay/
├── MobileDependencyResolver/
├── Settings/
└── Scripts/

Packages/
ProjectSettings/
TripleMatch.slnx
```

A maior parte da lógica encontra-se em:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/
```

O projeto contém aproximadamente:

- 83 scripts C#;
- 100 níveis em JSON;
- 3 cenas principais;
- prefabs de peças, boosters, popups e partículas;
- animações para menus, gameplay, vitória, derrota e transições;
- sons para gameplay e interface;
- ferramentas personalizadas para edição de níveis.

---

## 6. Cenas principais

### 6.1 HomeScene

Ficheiro:

```text
Assets/PuzzleMatchKit/Scenes/HomeScene.unity
```

Script:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Game/Scenes/HomeScene.cs
```

Responsabilidades:

- apresentar o menu principal;
- permitir iniciar o jogo;
- abrir as definições;
- ativar/desativar som;
- ativar/desativar música;
- apresentar a identidade visual do jogo.

As preferências são lidas através de:

```text
sound_enabled
music_enabled
```

### 6.2 LevelScene

Ficheiro:

```text
Assets/PuzzleMatchKit/Scenes/LevelScene.unity
```

Script:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Game/Scenes/LevelScene.cs
```

Responsabilidades:

- apresentar o mapa de níveis;
- mostrar níveis desbloqueados;
- indicar o nível seguinte;
- permitir selecionar níveis;
- posicionar o avatar;
- fazer scroll automático;
- animar o avatar quando um novo nível é desbloqueado.

O progresso utiliza principalmente:

```csharp
PlayerPrefs.GetInt("next_level");
```

### 6.3 GameScene

Ficheiro:

```text
Assets/PuzzleMatchKit/Scenes/GameScene.unity
```

Script:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Game/Scenes/GameScene.cs
```

É a cena principal de gameplay.

Responsabilidades:

- carregar o nível selecionado;
- criar a grelha;
- criar peças;
- processar interações;
- encontrar combinações;
- destruir peças;
- aplicar gravidade;
- preencher espaços vazios;
- processar boosters e obstáculos;
- calcular pontuação;
- verificar objetivos;
- controlar movimentos ou tempo;
- abrir popups de vitória e derrota;
- guardar estrelas e pontuação;
- desbloquear o nível seguinte.

Os níveis são carregados através de:

```text
Resources/Levels/<id>.json
```

Exemplos:

```text
Resources/Levels/1.json
Resources/Levels/2.json
Resources/Levels/100.json
```

---

## 7. Sistema de níveis

Existem atualmente **100 níveis em formato JSON**.

Localização:

```text
Assets/PuzzleMatchKit/Resources/Levels/
```

Cada nível pode conter:

- identificador;
- largura e altura da grelha;
- peças;
- obstáculos;
- limite de movimentos ou tempo;
- penalização;
- objetivos;
- cores disponíveis;
- pontuação para uma, duas e três estrelas;
- boosters disponíveis;
- recompensas;
- itens colecionáveis.

Classe principal:

```text
MergeSweetPals.Game.Common.Level
```

Campos relevantes:

```csharp
public int id;
public int width;
public int height;
public List<LevelTile> tiles;
public LimitType limitType;
public int limit;
public int penalty;
public List<Goal> goals;
public List<ColorBlockType> availableColors;
public int score1;
public int score2;
public int score3;
public bool awardBoostersWithRemainingMoves;
public BoosterType awardedBoosterType;
public int collectableChance;
public Dictionary<BoosterType, bool> availableBoosters;
```

### Curva de dificuldade

A documentação histórica descreve uma curva de dificuldade do tipo **sawtooth**:

- níveis difíceis;
- seguidos por níveis mais fáceis;
- repetição do padrão;
- redução da frustração;
- introdução progressiva de novas mecânicas.

---

## 8. Editor personalizado

Scripts:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Editor/GameSettingsTab.cs
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Editor/LevelEditorTab.cs
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Editor/PuzzleMatchKitEditor.cs
```

As ferramentas permitem:

- editar a configuração geral;
- criar níveis;
- editar grelhas;
- configurar peças;
- adicionar obstáculos;
- definir objetivos;
- definir movimentos ou tempo;
- configurar pontuações;
- configurar boosters;
- guardar níveis em JSON;
- guardar a configuração em JSON;
- apagar `PlayerPrefs` durante o desenvolvimento.

Fluxo de criação:

```text
Abrir editor
    ↓
Definir grelha
    ↓
Adicionar peças e obstáculos
    ↓
Definir objetivos
    ↓
Definir limite de movimentos/tempo
    ↓
Definir pontuação e recompensas
    ↓
Guardar ficheiro JSON
```

A principal vantagem é permitir criar novos níveis sem reconstruir manualmente cada cena Unity.

---

## 9. Arquitetura de scripts

### Core

Localização:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Core/
```

Inclui:

- transição entre cenas;
- sistema base de cenas;
- popups;
- áudio;
- música;
- efeitos sonoros;
- object pooling;
- botões animados;
- carregamento de ficheiros;
- controlo de FPS;
- troca de sprites.

Scripts importantes:

```text
BaseScene.cs
SceneTransition.cs
Popup.cs
ObjectPool.cs
SoundManager.cs
BackgroundMusic.cs
SoundFx.cs
FileUtils.cs
AnimatedButton.cs
```

### Game/Common

Inclui:

```text
PuzzleMatchManager.cs
GameConfiguration.cs
GameState.cs
Level.cs
Block.cs
BlockType.cs
Blocker.cs
BlockerType.cs
Booster.cs
BoosterType.cs
Bomb.cs
ColorBomb.cs
Dynamite.cs
CoinsSystem.cs
LivesSystem.cs
IapManager.cs
AdsSystem.cs
Loader.cs
GamePools.cs
TileEntity.cs
LevelTile.cs
Goal.cs
```

### Game/UI

Inclui:

- UI geral;
- objetivos;
- botões de boosters;
- moedas;
- vidas;
- pontuação;
- estrelas;
- avatar;
- níveis;
- anúncios recompensados;
- partículas.

### Game/Popups

Inclui popups para:

- início do jogo;
- vitória;
- derrota;
- falta de movimentos ou tempo;
- definições;
- compra de moedas;
- compra de vidas;
- compra de boosters;
- objetivos;
- saída;
- carregamento;
- recompensas.

---

## 10. PuzzleMatchManager

Ficheiro:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Game/Common/PuzzleMatchManager.cs
```

O `PuzzleMatchManager` é um singleton persistente e utiliza:

```csharp
DontDestroyOnLoad(gameObject);
```

Responsabilidades:

- persistir entre cenas;
- carregar `game_configuration.json`;
- inicializar vidas;
- inicializar moedas;
- inicializar preferências;
- disponibilizar `LivesSystem`;
- disponibilizar `CoinsSystem`;
- guardar o último nível selecionado;
- indicar se o nível seguinte foi desbloqueado;
- inicializar IAP quando `UNITY_IAP` está ativo.

Preferências inicializadas:

```text
num_lives
num_coins
sound_enabled
music_enabled
notifications_enabled
```

---

## 11. Configuração geral

Ficheiro:

```text
Assets/PuzzleMatchKit/Resources/game_configuration.json
```

Classe:

```text
GameConfiguration.cs
```

A configuração contém:

- número máximo de vidas;
- tempo para recuperar uma vida;
- custo para preencher vidas;
- moedas iniciais;
- movimentos extra;
- custo de movimentos;
- tempo extra;
- custo de tempo;
- pontuação padrão;
- pontuação por tipo de peça;
- combinações necessárias para obter boosters;
- quantidade inicial de boosters;
- custo dos boosters;
- zoom;
- escala do Canvas;
- configurações de resolução;
- IDs de anúncios;
- modo de teste;
- recompensa de anúncios;
- produtos de IAP.

### Multiplicador por nível

| Níveis | Multiplicador |
|---|---:|
| 1–20 | 1.0x |
| 21–40 | 1.1x |
| 41–60 | 1.2x |
| Seguintes | aumento progressivo |

### Multiplicador de combo

| Combo | Multiplicador |
|---|---:|
| 1 match | 1.0x |
| 2 matches | 1.2x |
| 3 matches | 1.4x |
| 4 ou mais | 1.6x |

---

## 12. Mecânicas Match-3

Fluxo principal:

```text
Detetar posição tocada
    ↓
Identificar peça
    ↓
Verificar obstáculos
    ↓
Verificar se é booster
    ↓
Encontrar peças ligadas
    ↓
Calcular pontuação
    ↓
Destruir peças
    ↓
Aplicar efeitos
    ↓
Destruir ou danificar obstáculos
    ↓
Aplicar gravidade
    ↓
Criar novas peças
    ↓
Atualizar objetivos
    ↓
Verificar vitória ou derrota
```

O jogo também possui lógica para destacar possíveis combinações quando o jogador fica algum tempo sem interagir.

---

## 13. Peças, obstáculos e boosters

### Peças

Classes relacionadas:

```text
Block.cs
TileEntity.cs
BlockType.cs
ColorBlockType.cs
```

### Obstáculos

Classes:

```text
Blocker.cs
BlockerType.cs
```

Exemplo:

```text
Assets/PuzzleMatchKit/Prefabs/Blockers/Ice.prefab
```

### Boosters

Boosters existentes:

- bomba horizontal;
- bomba vertical;
- dinamite;
- bomba de cor.

Prefabs:

```text
Assets/PuzzleMatchKit/Prefabs/Boosters/
```

Ficheiros:

```text
ColorBomb.prefab
Dynamite.prefab
HorizontalBomb.prefab
VerticalBomb.prefab
```

Os boosters podem ser obtidos através de combinações, comprados com moedas, atribuídos como recompensa e configurados individualmente por nível.

---

## 14. Pontuação e estrelas

Cada nível pode definir:

```text
score1
score2
score3
```

Estes valores determinam uma, duas ou três estrelas.

A pontuação pode considerar:

- peças destruídas;
- boosters;
- obstáculos destruídos;
- combos;
- multiplicador do nível;
- objetivos cumpridos.

O progresso é guardado com chaves como:

```text
level_stars_<id>
level_score_<id>
```

---

## 15. Objetivos dos níveis

Os objetivos são representados por:

```text
Goal.cs
```

A interface utiliza:

```text
GoalUi.cs
GoalUiElement.cs
```

Os objetivos podem incluir:

- obter determinada pontuação;
- destruir blocos específicos;
- remover obstáculos;
- recolher itens;
- cumprir vários objetivos simultaneamente.

---

## 16. Limites de movimentos e tempo

Cada nível pode ser baseado em:

```text
LimitType.Moves
```

ou:

```text
LimitType.Time
```

Quando o limite é atingido, é aberto:

```text
NoMovesOrTimePopup.cs
```

Dependendo da configuração, o jogador pode comprar movimentos, comprar tempo, utilizar moedas ou assistir a um anúncio recompensado.

---

## 17. Sistema de vidas

Ficheiro:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Game/Common/LivesSystem.cs
```

Funcionalidades:

- adicionar vidas;
- remover vidas;
- recuperar vidas automaticamente;
- preencher vidas com moedas;
- calcular o tempo até à próxima vida;
- atualizar a UI através de callbacks;
- recalcular vidas quando a aplicação regressa do background.

Chaves:

```text
num_lives
next_life_time
```

As vidas são recuperadas usando o tempo do sistema.

---

## 18. Sistema de moedas

Ficheiro:

```text
Assets/PuzzleMatchKit/Scripts/Merge Sweet Pals/Game/Common/CoinsSystem.cs
```

As moedas podem ser usadas para:

- comprar boosters;
- preencher vidas;
- comprar movimentos extra;
- comprar tempo extra;
- aceder a recompensas.

Chave principal:

```text
num_coins
```

UI relacionada:

```text
BuyCoinsBar.cs
BuyCoinsPopup.cs
BuyLivesPopup.cs
BuyBoostersPopup.cs
```

---

## 19. Persistência de dados

### JSON

Usado para:

- configurações;
- níveis;
- grelhas;
- objetivos;
- pontuações;
- boosters;
- obstáculos.

Utilitário:

```text
FileUtils.cs
```

Biblioteca:

```text
FullSerializer
```

### PlayerPrefs

Usado para:

- vidas;
- moedas;
- boosters;
- nível seguinte;
- estrelas;
- pontuação;
- som;
- música;
- notificações;
- avatar.

Exemplos:

```text
num_lives
num_coins
next_level
level_stars_1
level_score_1
num_boosters_0
sound_enabled
music_enabled
notifications_enabled
avatar_selected
```

O progresso atual é local. `PlayerPrefs` não oferece, por si só, sincronização entre dispositivos ou contas online.

---

## 20. Monetização — Unity IAP

Package:

```text
com.unity.purchasing
```

Script:

```text
IapManager.cs
```

O sistema utiliza produtos consumíveis.

Fluxo esperado:

```text
Carregar produtos
    ↓
Inicializar Unity Purchasing
    ↓
Verificar loja
    ↓
Apresentar produtos
    ↓
Iniciar compra
    ↓
Receber callback
    ↓
Identificar produto
    ↓
Adicionar moedas/recompensas
    ↓
Mostrar confirmação
```

Os produtos são configurados através de `IapItem` em:

```text
game_configuration.json
```

A documentação original refere cinco bundles de moedas preparados para App Store e Google Play. A validação final em ambiente de produção deve ser considerada uma etapa adicional.

---

## 21. Anúncios recompensados — LevelPlay

Package:

```text
com.unity.services.levelplay
```

Ficheiros:

```text
Assets/LevelPlay/
Assets/MobileDependencyResolver/
```

Scripts:

```text
AdsSystem.cs
RewardedAdButton.cs
```

Os anúncios podem oferecer:

- vidas;
- moedas;
- movimentos extra;
- tempo extra;
- boosters.

No código atual, algumas partes ainda são placeholders. A ativação final, configuração dos Ad Units e validação em dispositivos reais ainda devem ser confirmadas.

Formulação recomendada:

> A arquitetura de anúncios recompensados está preparada através do LevelPlay, estando a ativação final e a validação em produção identificadas como trabalho futuro.

---

## 22. Refatoração e dívida técnica

A documentação histórica indica que o projeto começou como um template legado com elevado acoplamento.

A refatoração teve como objetivos:

- reduzir acoplamento;
- separar responsabilidades;
- melhorar a manutenção;
- separar UI e regras de negócio;
- resolver problemas de persistência;
- criar uma arquitetura escalável;
- melhorar a organização do código;
- corrigir problemas de renderização e hierarquia da UI.

A documentação antiga menciona:

```text
GameManager
LevelLoader
ScoreController
PowerUpHandler
```

No código atual, os principais nomes são:

```text
PuzzleMatchManager
GameScene
GameConfiguration
GameState
Level
Booster
LivesSystem
CoinsSystem
```

A apresentação deve explicar a evolução arquitetural sem misturar automaticamente os nomes antigos e atuais.

---

## 23. Deadlock e movimentos possíveis

A documentação histórica descreve um algoritmo para evitar que a grelha fique sem movimentos legais.

Lógica descrita:

1. analisar trocas entre peças vizinhas;
2. simular cada troca;
3. verificar se a troca cria um Match-3;
4. desfazer a troca;
5. continuar até encontrar um movimento válido;
6. se não existir nenhum movimento, considerar a grelha bloqueada;
7. baralhar as peças;
8. gerar uma nova distribuição com pelo menos um movimento válido.

Pseudocódigo:

```text
FUNÇÃO DetetarDeadlock(Grelha G)

    PARA CADA peça P na grelha G
        PARA CADA direção D
            SE existir vizinho de P na direção D
                Simular troca entre P e o vizinho

                SE a troca criar um match
                    Desfazer troca
                    RETORNAR falso
                FIM SE

                Desfazer troca
            FIM SE
        FIM PARA
    FIM PARA

    RETORNAR verdadeiro
FIM FUNÇÃO
```

No código atual analisado não foi encontrada uma implementação claramente identificada com os nomes `Deadlock`, `Shuffle` ou `HasPossibleMove`.

Existe um `NoMovesOrTimePopup`, mas este está relacionado com o limite de movimentos ou tempo do nível e não prova, por si só, a existência de prevenção de deadlock.

Na apresentação, este tópico deve ser descrito como funcionalidade documentada anteriormente ou como funcionalidade a validar, salvo existência de provas adicionais.

---

## 24. Interface, animação e áudio

O projeto possui:

- sprites;
- sprite atlases;
- materiais;
- partículas;
- animações;
- fontes;
- sons;
- efeitos de brilho;
- confetti;
- transições;
- popups animados.

Existem animações para:

- botões;
- boosters;
- peças;
- popups;
- vitória;
- derrota;
- estrelas;
- avatar;
- loading;
- confetti;
- partículas.

A biblioteca utilizada para várias animações e transições é:

```text
LeanTween
```

Scripts de áudio:

```text
SoundManager.cs
BackgroundMusic.cs
SoundFx.cs
PlaySound.cs
```

O projeto inclui música de fundo, sons de vitória e derrota, sons de combinações, bombas, gelo, pedra, moedas, boosters e botões.

---

## 25. Dependências principais

```text
com.unity.inputsystem
com.unity.purchasing
com.unity.render-pipelines.universal
com.unity.services.levelplay
com.unity.ugui
com.unity.timeline
com.unity.test-framework
```

Também são utilizados:

- Universal Render Pipeline;
- Unity Input System;
- Unity UI;
- Unity Purchasing;
- LevelPlay;
- LeanTween;
- FullSerializer;
- Mobile Dependency Resolver.

---

## 26. Estado atual do Git

O repositório possui uma história Git curta.

Commit principal:

```text
fb3c37f — bug fixes
```

Esse commit contém praticamente todo o projeto atual:

- código;
- cenas;
- níveis;
- prefabs;
- animações;
- áudio;
- configurações;
- dependências;
- assets visuais.

Por isso, o Git não apresenta detalhadamente todas as etapas da evolução. O histórico técnico deve ser explicado com base na documentação fornecida pelo desenvolvedor e no código atual.

---

## 27. Pontos fortes

1. **100 níveis jogáveis** em JSON.
2. **Editor personalizado** para criação de níveis.
3. **Arquitetura modular** para vidas, moedas, boosters, IAP e gameplay.
4. **Progressão** através de estrelas, pontuação, mapa, avatar e desbloqueios.
5. **Economia mobile** com vidas, moedas e boosters.
6. **Experiência audiovisual** com partículas, sons e animações.
7. **Preparação para monetização** com Unity IAP e LevelPlay.
8. **Escalabilidade** para novos níveis, objetivos e boosters.
9. **Persistência local** entre sessões.
10. **Ferramentas internas** que reduzem trabalho manual.

---

## 28. Limitações e pontos a validar

A apresentação deve ser transparente sobre:

- anúncios ainda necessitarem de validação final;
- IAP necessitar de testes reais em dispositivos e lojas;
- ausência de analytics confirmado no código atual;
- ausência de Firebase confirmado;
- ausência de funcionalidades online confirmadas;
- ausência de pipeline iOS no repositório;
- algoritmo de deadlock/shuffle a validar;
- documentação histórica usar nomes de classes diferentes dos atuais;
- `PlayerPrefs` ser armazenamento local;
- acessibilidade ainda estar pendente;
- publicação comercial ainda não estar comprovada apenas pelo código.

---

## 29. Roadmap futuro

### Publicação iOS

Criar pipeline com Codemagic, Xcode Cloud ou serviço equivalente para:

- gerar `.ipa`;
- distribuir para TestFlight;
- automatizar builds;
- reduzir dependência de hardware macOS local.

### Monetização

Finalizar:

- Unity IAP;
- IDs dos produtos;
- testes de compras;
- tratamento de falhas;
- LevelPlay;
- anúncios recompensados;
- consentimento;
- privacidade;
- validação nas lojas.

### Analytics

Medir:

- retenção D1;
- retenção D7;
- abandono por nível;
- taxa de vitória;
- utilização de boosters;
- visualizações de anúncios;
- conversão de compras;
- duração das sessões.

### Funcionalidades online

Avaliar Firebase ou solução equivalente para:

- eventos temporários;
- leaderboards;
- sincronização de progresso;
- configuração remota;
- campanhas sazonais;
- notificações;
- testes A/B.

### Acessibilidade

Melhorar:

- contraste;
- diferenciação entre cores;
- suporte a daltonismo;
- tamanho dos elementos;
- legibilidade;
- feedback que não dependa apenas da cor;
- compatibilidade com WCAG 2.1 AA quando aplicável.

### Expansão de conteúdo

Expandir de:

```text
100 níveis
```

para:

```text
250 níveis ou mais
```

utilizando as ferramentas de editor existentes.

---

# Orientação para criar a apresentação PowerPoint

A apresentação deve ser académica, profissional, visual, tecnicamente credível e coerente com a estética de confeitaria.

Para cada slide, criar:

1. título;
2. texto curto visível;
3. sugestão visual;
4. notas detalhadas do apresentador;
5. transição para o slide seguinte.

Não colocar parágrafos longos nos slides. Usar notas do apresentador para explicar a parte técnica.

## Estrutura recomendada dos slides

### Slide 1 — Capa

**Sweet Merge Pals**

Subtítulo:

> Desenvolvimento de um jogo mobile casual Match-3/Merge em Unity

Adicionar nome, curso, instituição, data e imagem do jogo.

### Slide 2 — Contexto

Explicar:

- crescimento dos jogos mobile;
- popularidade do género Match-3;
- importância de sessões curtas;
- inspiração em Candy Crush Saga e Royal Match.

### Slide 3 — Conceito do jogo

Mostrar:

- tema de confeitaria;
- objetivo principal;
- ciclo de jogo;
- estética visual;
- plataformas-alvo.

### Slide 4 — Objetivos do projeto

Apresentar:

- desenvolver um jogo jogável;
- criar 100 níveis;
- implementar progressão;
- desenvolver economia;
- preparar monetização;
- criar ferramentas internas;
- construir uma base escalável.

### Slide 5 — Público-alvo

O jogo destina-se a:

- jogadores mobile casuais;
- pessoas que preferem sessões curtas;
- jogadores motivados por progressão;
- jogadores interessados em conquistas;
- utilizadores que gostam de experiências relaxantes e visuais.

### Slide 6 — Game Design MDA

Dividir em:

- Mechanics;
- Dynamics;
- Aesthetics.

Utilizar exemplos concretos do projeto.

### Slide 7 — Gameplay loop

```text
Selecionar peças
      ↓
Criar combinação
      ↓
Destruir peças
      ↓
Preencher grelha
      ↓
Cumprir objetivos
      ↓
Ganhar estrelas
      ↓
Desbloquear nível
```

### Slide 8 — Arquitetura técnica

```text
PuzzleMatchManager
        ↓
GameConfiguration
        ↓
LivesSystem / CoinsSystem / IapManager
        ↓
HomeScene / LevelScene / GameScene
        ↓
Blocks / Boosters / Blockers / Goals
```

### Slide 9 — Organização do projeto

Mostrar:

- Scenes;
- Scripts;
- Prefabs;
- Resources;
- Animations;
- Sounds;
- Settings;
- Editor.

### Slide 10 — Cenas principais

Explicar:

- HomeScene;
- LevelScene;
- GameScene.

Adicionar screenshots ou um diagrama de navegação.

### Slide 11 — Sistema de níveis

Mostrar:

- 100 níveis;
- ficheiros JSON;
- grelhas configuráveis;
- objetivos;
- limites;
- pontuações;
- boosters;
- obstáculos.

### Slide 12 — Editor personalizado

Explicar que o editor permite:

- criar níveis;
- configurar peças;
- adicionar obstáculos;
- definir objetivos;
- definir dificuldade;
- guardar ficheiros JSON;
- testar configurações.

Realçar a redução do trabalho manual.

### Slide 13 — Mecânicas principais

Explicar:

- combinação de peças;
- destruição;
- queda;
- reposição;
- combos;
- pontuação;
- objetivos.

### Slide 14 — Boosters e obstáculos

Apresentar:

- bomba horizontal;
- bomba vertical;
- dinamite;
- bomba de cor;
- gelo;
- outros obstáculos.

### Slide 15 — Progressão

Explicar:

- estrelas;
- pontuação;
- desbloqueio de níveis;
- mapa;
- avatar;
- dificuldade progressiva;
- curva de dificuldade sawtooth.

### Slide 16 — Economia

```text
Vidas → limitam tentativas
Moedas → permitem compras
Boosters → facilitam níveis
Recompensas → incentivam progressão
```

### Slide 17 — Monetização

Explicar:

- Unity IAP;
- produtos consumíveis;
- bundles de moedas;
- anúncios recompensados;
- LevelPlay;
- possíveis recompensas.

Indicar claramente o que está implementado e o que está preparado.

### Slide 18 — Persistência

Explicar:

- JSON para configurações e níveis;
- `PlayerPrefs` para progresso local;
- vidas;
- moedas;
- estrelas;
- pontuações;
- preferências;
- boosters.

### Slide 19 — Refatoração

Apresentar:

- código legado acoplado;
- separação de responsabilidades;
- sistemas especializados;
- melhoria da manutenção;
- separação entre UI e lógica;
- preparação para escalabilidade.

### Slide 20 — Qualidade audiovisual

Mostrar:

- partículas;
- animações;
- confetti;
- sons;
- efeitos de vitória;
- feedback de combinações;
- transições;
- identidade visual.

### Slide 21 — Resultados

Apresentar:

- 100 níveis;
- gameplay funcional;
- cenas completas;
- progressão;
- economia;
- boosters;
- editor personalizado;
- arquitetura de monetização;
- suporte técnico para Android/iOS.

### Slide 22 — Limitações

Indicar:

- anúncios a validar;
- IAP a testar em produção;
- ausência de analytics;
- ausência de funcionalidades online;
- acessibilidade pendente;
- deadlock/shuffle a confirmar;
- necessidade de pipeline iOS.

### Slide 23 — Roadmap

1. CI/CD para iOS;
2. finalizar monetização;
3. adicionar analytics;
4. integrar backend;
5. melhorar acessibilidade;
6. adicionar eventos;
7. expandir para 250 níveis.

### Slide 24 — Conclusão

Mensagem sugerida:

> Sweet Merge Pals demonstra a criação de um jogo mobile casual completo, combinando design de jogo, programação em Unity, ferramentas de produção de conteúdo, progressão, economia e preparação para monetização. O projeto apresenta uma base funcional e escalável para futura publicação e expansão.

### Slide 25 — Demonstração e perguntas

Adicionar:

- screenshots;
- vídeo de gameplay;
- QR code, se existir;
- convite para perguntas.

---

## Estilo visual recomendado

Utilizar:

- cores pastel;
- rosa, amarelo, azul e creme;
- elementos de confeitaria;
- tipografia arredondada;
- screenshots do jogo;
- diagramas simples;
- pouco texto por slide;
- notas do apresentador detalhadas.

A apresentação deve transmitir uma imagem:

- profissional;
- académica;
- visual;
- coerente com o jogo;
- tecnicamente credível;
- transparente quanto ao estado real do projeto.
