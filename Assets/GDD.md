**Ashes of Balance**

Game Design Document

Versão: 1.0

Author

Fabio William Conceição

[1\. Ideias Centrais: O Conceito de "Ashes of Balance"](#1.-ideias-centrais:-o-conceito-de-"ashes-of-balance")

[A. O Título e o Conceito Central](#a.-o-título-e-o-conceito-central)

[B. O Personagem (Player)](#b.-o-personagem-\(player\))

[C. O Escopo (O MVP)](#c.-o-escopo-\(o-mvp\))

[2\. O Rascunho do GDD: Detalhamento por Seção](#2.-o-rascunho-do-gdd:-detalhamento-por-seção)

[1\. Visão Geral do Jogo](#1.-visão-geral-do-jogo)

[2\. História de Background](#2.-história-de-background)

[3\. Restrições e Justificativas de Design (Como no Codex)](#3.-restrições-e-justificativas-de-design-\(como-no-codex\))

[4\. Sistema de Combate e Atributos (Ruleset)](#4.-sistema-de-combate-e-atributos-\(ruleset\))

[4.1. Definição dos Atributos (Stats)](#4.1.-definição-dos-atributos-\(stats\))

[4.2. Ações do Player (O Moveset do Vigilante)](#4.2.-ações-do-player-\(o-moveset-do-vigilante\))

[4.3. Loop de Combate (Game Feel)](#4.3.-loop-de-combate-\(game-feel\))

[4.4. Regra de Dano (Fórmula Central)](#4.4.-regra-de-dano-\(fórmula-central\))

[5\. Design de Níveis e Progressão (Os 5 Focos de Corrupção)](#5.-design-de-níveis-e-progressão-\(os-5-focos-de-corrupção\))

[5.1. Fases e Desafios (MVP)](#5.1.-fases-e-desafios-\(mvp\))

[5.2. Progressão do Player](#5.2.-progressão-do-player)

[6\. Estratégia de Assets (Garantindo o "Free")](#6.-estratégia-de-assets-\(garantindo-o-"free"\))

[6.1. Estilo Visual e Assets 3D](#6.1.-estilo-visual-e-assets-3d)

[6.2. Assets de Interface do Usuário (UI/UX)](#6.2.-assets-de-interface-do-usuário-\(ui/ux\))

[6.3. Assets de Áudio e Música](#6.3.-assets-de-áudio-e-música)

[8\. Atributos Iniciais e Balanceamento (Level 1\)](#8.-atributos-iniciais-e-balanceamento-\(level-1\))

[8.1. Atributos Base do Vigilante (Level 1\)](#8.1.-atributos-base-do-vigilante-\(level-1\))

[8.2. Resumo das Capacidades no Nível 1](#8.2.-resumo-das-capacidades-no-nível-1)

[10\. Estrutura de Progressão (Sistema de Nível)](#10.-estrutura-de-progressão-\(sistema-de-nível\))

[10.1. Progressão de Nível (LVL) e XP](#10.1.-progressão-de-nível-\(lvl\)-e-xp)

[10.2. Crescimento Base de Atributos (Stats Base Growth)](#10.2.-crescimento-base-de-atributos-\(stats-base-growth\))

[10.3. Distribuição de Pontos de Atributos (Player Choice)](#10.3.-distribuição-de-pontos-de-atributos-\(player-choice\))

[10.4. Exemplo de Build Final (LVL 5\)](#10.4.-exemplo-de-build-final-\(lvl-5\))

[12\. Design de Inimigos (Os Constructos de Cinza)](#12.-design-de-inimigos-\(os-constructos-de-cinza\))

[A. Inimigos Comuns (Fase 1 a 3\)](#a.-inimigos-comuns-\(fase-1-a-3\))

[B. Mini-Bosses e Bosses (Fase 1 a 3\)](#b.-mini-bosses-e-bosses-\(fase-1-a-3\))

[13\. Mecânicas Opcionais (Detalhando Áreas e Documentos)](#13.-mecânicas-opcionais-\(detalhando-áreas-e-documentos\))

[13.1. Áreas Secretas (Baixo Custo de Desenvolvimento)](#13.1.-áreas-secretas-\(baixo-custo-de-desenvolvimento\))

[13.2. Documentos (Lore e Justificativa)](#13.2.-documentos-\(lore-e-justificativa\))

##  

## **1\. Ideias Centrais: O Conceito de "Ashes of Balance"** {#1.-ideias-centrais:-o-conceito-de-"ashes-of-balance"}

O conceito de jogo que usaremos é a **Ação Tática de Peso**, onde cada movimento é deliberado e a esquiva (rola) é o
recurso mais importante.

### **A. O Título e o Conceito Central** {#a.-o-título-e-o-conceito-central}

* **Título:** Ashes of Balance (Cinzas do Equilíbrio).
* **Logline:** Um Action RPG Isométrico onde o último Guardião da Ordem deve purificar 5 zonas corrompidas, usando o
  *Dodge* como sua principal ferramenta de sobrevivência em um mundo onde a energia vital está constantemente sendo
  drenada.
* **Conflito:** O mundo foi transformado em Cinzas (a corrupção) que drenam a vitalidade e a magia (MP) de quem está
  dentro delas.
* **Regra de Ouro (Mecânica e História):** A Rolada de Desvio (*Dodge*) **não é apenas uma esquiva**, é o ato de quebrar
  a conexão com as Cinzas, recuperando temporariamente a velocidade e a vitalidade.

### **B. O Personagem (Player)** {#b.-o-personagem-(player)}

Para justificar o seu *moveset* restrito (Ataque Forte/Básico, Rolar/Desviar, Especial), usaremos a ideia de um guerreiro
que usa uma armadura/mecanismo especial:

* **Nome Proposto:** O **Vigilante (The Watcher)**.
* **Status:** O último membro de uma Ordem Ancestral responsável por manter o equilíbrio.
* **Equipamento Principal (Justificativa dos Assets):** O Vigilante está dentro de uma **Armadura de Ferro-Cinza** (
  Dark/Low Poly Armor Asset).
    * **Justificativa do Não-Pulo:** A armadura é pesada demais ou o Protocolo (como no *Codex*) proíbe saltos para
      manter o *momentum* e o foco no solo.
    * **Justificativa do Dodge (Rola):** A "Rola" é uma liberação temporária de energia cinética que permite ao
      Vigilante *deslizar* e ganhar invencibilidade. Essa ação **consome MP (Energia Vital)** porque é um esforço não
      natural para a armadura.

### **C. O Escopo (O MVP)** {#c.-o-escopo-(o-mvp)}

* **O que "Ashes of Balance" significa na História?**
    * As "Cinzas" são a matéria corrompida.
    * O "Equilíbrio" é a força que o Vigilante tenta restaurar.
* **A Jornada MVP (5 Fases):** As 5 fases representam os **5 Focos de Corrupção Primários** que precisam ser selados
  antes que o prazo (23 de dezembro) chegue, ou seja, antes que a Corrupção se torne irreversível.
* **A Missão:** O Vigilante deve ativar 5 **Selos Isométricos** (justificando a câmera) localizados no final de cada
  fase.

### **2\. O Rascunho do GDD: Detalhamento por Seção** {#2.-o-rascunho-do-gdd:-detalhamento-por-seção}

Com essas ideias centrais, podemos estruturar as primeiras seções do GDD:

#### **1\. Visão Geral do Jogo** {#1.-visão-geral-do-jogo}

| Campo           | Detalhe                                                                               |
|:----------------|:--------------------------------------------------------------------------------------|
| **Título**      | Ashes of Balance                                                                      |
| **Gênero**      | Action RPG (ARPG) Isométrico / Dungeon Crawler                                        |
| **Engine**      | Unity 3D                                                                              |
| **Plataformas** | PC (Foco no desenvolvimento inicial)                                                  |
| **Prazo MVP**   | 23 de Dezembro (Finalização dos 5 níveis e Boss)                                      |
| **Metodologia** | **TDD (Test-Driven Development)**: Garantia de *game feel* e estabilidade de combate. |

####  

#### **2\. História de Background** {#2.-história-de-background}

* **A Ordem:** A Ordem do Equilíbrio, uma sociedade de artesãos e guerreiros que utilizam tecnologia ancestral e
  *soul-tech* para manter a integridade do plano material.
* **O Evento das Cinzas:** Uma catástrofe que transformou a magia em Cinza corrompida, que consome a vitalidade. **As
  Cinzas são o *Asset* mais importante e visualmente genérico do jogo** (Fácil de fazer com partículas *free*).
* **O Vigilante (O Player):** Último operativo da Ordem, usando uma Armadura Prototipo (Móvel, mas Pesada).
* **O Objetivo:** Ativar os 5 Selos, que exigem a presença do Vigilante para serem reativados e purificar os 5 Focos de
  Corrupção.

#### **3\. Restrições e Justificativas de Design (Como no *Codex*)
** {#3.-restrições-e-justificativas-de-design-(como-no-codex)}

| Restrição                | Justificativa de Design                                                                                                                                                                    | Implicação no TDD                                                                                                                     |
|:-------------------------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------------------------------|
| **Assets Free**          | O mundo é composto por "Constructos de Cinza" e "Vigias" genéricos, que se formaram a partir das Cinzas. (Permite usar *assets* 3D low-poly de inimigos variados, mas visualmente coesos). | Testes focados na **Lógica de IA** (movimento, padrões de ataque) e não em animações complexas.                                       |
| **Câmera Isométrica**    | O campo de visão é fixo, um requisito dos Selos de Purificação.                                                                                                                            | O **Teste de Movimentação** deve garantir que o vetor de movimento para o clique do mouse/joystick esteja sempre correto (isometria). |
| **Sem Mecânica de Pulo** | A Armadura Prototipo é selada no chão para manter a estabilidade do campo de energia.                                                                                                      | Simplifica o desenvolvimento da física e colisões. O **Teste de Colisão** deve ser robusto.                                           |
| **Uso de MP para Dodge** | O *Dodge* é uma liberação de energia cinética bruta para quebrar o vínculo das Cinzas com o chão, custando *Magic Points* (MP).                                                            | O **Teste de Recurso** deve garantir que o jogador seja penalizado ao tentar rolar sem MP e que a regeneração passiva de MP funcione. |

---

## **4\. Sistema de Combate e Atributos (Ruleset)** {#4.-sistema-de-combate-e-atributos-(ruleset)}

Esta seção define as regras matemáticas do jogo, que serão o primeiro alvo do seu TDD (Test-Driven Development).

### **4.1. Definição dos Atributos (Stats)** {#4.1.-definição-dos-atributos-(stats)}

O Vigilante (Player) e todos os inimigos terão os seguintes atributos:

| Stat    | Definição                                                       | Efeito no Jogo (Regras)                                                                                                                                      | Foco do TDD                                    |
|:--------|:----------------------------------------------------------------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------------------------------------|
| **HP**  | Pontos de Vida. Se chegar a 0, o Player morre.                  | O *Pool* de vida do Player.                                                                                                                                  | Teste de Sobrevivência (Receber Dano \> 0).    |
| **MP**  | Pontos de Magia/Energia Cinética. Recurso para ações especiais. | Regeneração passiva (ex: \+5 MP/s).                                                                                                                          | Teste de Regeneração de MP.                    |
| **ATQ** | Valor base do dano físico (Ataque Básico e Forte).              | 1 Ponto de ATQ aumenta o Dano Básico em **1 ponto**.                                                                                                         | Teste de Cálculo de Dano Físico.               |
| **INT** | Valor base do dano mágico (Ataque Especial).                    | 1 Ponto de INT aumenta o Dano Especial em **1 ponto** e reduz o custo de MP da Rolada.                                                                       | Teste de Cálculo de Dano Mágico e Custo de MP. |
| **DEF** | Redução de Dano (Mitigação).                                    | Redução Percentual: Dano Recebido \= Dano Bruto [![][image1]](https://www.codecogs.com/eqnedit.php?latex=%5Ctimes%20\(1%20-%20%5Cfrac%7BDEF%7D%7B100%7D\)#0) | Teste de Mitigação de Dano (Regra de DEF).     |

### **4.2. Ações do Player (O *Moveset* do Vigilante)** {#4.2.-ações-do-player-(o-moveset-do-vigilante)}

**Regra TDD:** Cada ação deve ter um teste unitário para garantir que o dano e os custos estão corretos.

| Ação                    | Tipo de Dano                   | Custo de MP                                                                              | Cooldown (CD) | Fórmula de Dano/Efeito                                                                                                                             |
|:------------------------|:-------------------------------|:-----------------------------------------------------------------------------------------|:--------------|:---------------------------------------------------------------------------------------------------------------------------------------------------|
| **1\. Ataque Básico**   | Físico (Single Target)         | 0 MP                                                                                     | 0.5s          | Dano Bruto \= [![][image2]](https://www.codecogs.com/eqnedit.php?latex=ATQ%20%5Ctimes%201.0#0) (Rápido, principal fonte de dano sustentável).      |
| **2\. Ataque Forte**    | Físico (Single Target)         | 10 MP                                                                                    | 3.0s          | Dano Bruto \= [![][image3]](https://www.codecogs.com/eqnedit.php?latex=ATQ%20%5Ctimes%201.8#0) (Alto dano, ideal para inimigos lentos/bosses).     |
| **3\. Rolar/Desviar**    | N/A (Movimentação)             | 5 MP \- (INT [![][image4]](https://www.codecogs.com/eqnedit.php?latex=%5Ctimes%200.1#0)) | 0.5s          | **Invencibilidade (i-frames)** de 0.25 segundos durante a animação. O custo é reduzido pela INT.                                                   |
| **4\. Ataque Especial** | Mágico (Area of Effect \- AOE) | 25 MP                                                                                    | 8.0s          | Dano Bruto \= [![][image5]](https://www.codecogs.com/eqnedit.php?latex=INT%20%5Ctimes%202.0#0) (Útil contra hordas, gasta o recurso mais valioso). |

### **4.3. Loop de Combate (Game Feel)** {#4.3.-loop-de-combate-(game-feel)}

A essência do combate será a gestão de MP e o timing da esquiva:

1. O Player usa **Ataque Básico** para causar dano e deixar o MP regenerar passivamente.
2. Quando confrontado com dano inevitável, usa **Rolar/Desviar**, consumindo o MP.
3. O Player usa **Ataque Forte** e **Ataque Especial** quando há MP suficiente e eles não estão em Cooldown, forçando a
   escolha: **Dano Máximo** ou **Recurso para Sobrevivência (Rolar)**.

### **4.4. Regra de Dano (Fórmula Central)** {#4.4.-regra-de-dano-(fórmula-central)}

Todos os testes de dano seguirão esta regra:

[![][image6]](https://www.codecogs.com/eqnedit.php?latex=%5Ctext%7BDano%20Final%7D%20%3D%20%5Ctext%7BDano%20Bruto%7D%20%5Ctimes%20%5Cleft\(1%20-%20%5Cfrac%7B%5Ctext%7BDEF%20do%20Alvo%7D%7D%7B100%7D%5Cright\)#0)

* *O TDD deve incluir um caso de teste para a DEF máxima (ex: 70 DEF), confirmando que 30% do dano bruto é aplicado.*

---

## **5\. Design de Níveis e Progressão (Os 5 Focos de Corrupção)
** {#5.-design-de-níveis-e-progressão-(os-5-focos-de-corrupção)}

Vamos usar a limitação de 5 fases para criar um "tutorial" de combate, onde cada Fase força o Player a dominar uma
mecânica diferente.

### **5.1. Fases e Desafios (MVP)** {#5.1.-fases-e-desafios-(mvp)}

| Foco de Corrupção (Fase) | Nome Proposto            | Desafio de Combate                                                                                                                                                      | Mini-Boss                                                                                                             |
|:-------------------------|:-------------------------|:------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------------------------------------------------------------------------------------------------------------------|
| **Fase 1**               | **O Grito das Raízes**   | **Controle Básico e Posicionamento.** Inimigos lentos, focados em combate corpo-a-corpo. Força o uso do **Ataque Básico** e **Forte**.                                  | **O Golem Lento:** Lento, mas com muito HP e DEF. Ensina a importância de ter **ATQ**.                                |
| **Fase 2**               | **O Pântano dos Vigias** | **Gestão de MP para Esquiva.** Introduz inimigos de longo alcance (arqueiros/magos) que atiram projéteis previsíveis. Força o uso estratégico do **Rolar/Desviar**.      | **O Tático de Cinza:** Mini-Boss que não ataca, mas invoca 2-3 atiradores. Ensina a priorização de alvos e o *Dodge*. |
| **Fase 3**               | **A Cidade Sufocada**    | **Dano em Área (AOE) e Hordas.** Níveis estreitos e cheios de inimigos fracos e numerosos. Força o uso do **Ataque Especial** (INT).                                    | **A Matriz:** Uma estrutura estacionária que expele ondas constantes de *Minions* (Slimes). Ensina a gestão de CD.    |
| **Fase 4**               | **O Vazio de Vidro**     | **Punição por Erro (Alto Dano/Baixa DEF).** Inimigos muito rápidos ou com *burst* de dano alto. Força o uso de **i-frames** da Rola e exige alta performance do Player. | **O Caçador Veloz:** Rápido, com baixo HP, mas um combo de 3-hits devastador. Exige precisão na esquiva.              |
| **Fase 5**               | **O Núcleo da Balança**  | **Teste de Combinação de Habilidades.** O nível final combina todos os tipos de inimigos.                                                                               | **Boss Final (A Corrupção):** Com padrões que exigem **Dodge, AOE e Single-Target**.                                  |

### **5.2. Progressão do Player** {#5.2.-progressão-do-player}

* **Nível Máximo:** O MVP terá o nível máximo de **LVL 5**.
* **XP por Nível:** Simplificado (Ex: 100 XP para o Nível 2, 200 XP para o Nível 3, etc.).
* **Aumento de Atributos:** A cada nível, o Player ganha **3 Pontos** para distribuir livremente entre **ATQ, DEF, e INT
  ** (HP e MP aumentam automaticamente em \+5 e \+2, respectivamente, a cada nível).

## **6\. Estratégia de Assets (Garantindo o "Free")** {#6.-estratégia-de-assets-(garantindo-o-"free")}

### **6.1. Estilo Visual e Assets 3D** {#6.1.-estilo-visual-e-assets-3d}

Para garantir a coesão visual e a disponibilidade de *assets* 3D gratuitos, o estilo deve ser simples e amplamente
disponível.

* **Estilo Adotado:** **Low-Poly Fantasia Sombria/Estilizada.**
    * *Por quê?* **Low-Poly** é o estilo com a maior variedade e qualidade de *assets* gratuitos (modelos simples,
      texturas básicas).
    * **Fantasia Sombria** justifica cores escuras e a aparência de "constructos" ou "monstros de cinza" (fácil de
      *re-skin*/recolorir modelos genéricos).
* **Aparência do Personagem (O Vigilante):** Armadura de cor cinza escura/chumbo. A arma (espada, machado, martelo) deve
  ser grande e visível (para ter impacto no *game feel*).
    * *Sugestão de Busca (Unity Asset Store/Itch.io/Sketchfab):* "Low Poly Knight Free", "Stylized Character Free", "
      Dark Fantasy Weapon Free".
* **Aparência dos Inimigos (Os Constructos de Cinza):** Use modelos *low-poly* de esqueletos, slimes, ou golem, mas
  aplique uma cor uniforme escura ou um material de "cinza" genérico.
    * *Justificativa de História:* Como são constructos de cinza, eles não precisam de animações de morte complexas (
      podem simplesmente desmoronar em partículas de cinza, o que é mais fácil de programar e garante o *asset* free).
* **Ambientes (As 5 Fases):** As fases devem ser baseadas em *tiles* e prefabs simples, como rochas, árvores mortas e
  ruínas.
    * *Sugestão:* Use pacotes de "Low Poly Environment" que geralmente fornecem kits de construção modular.

### **6.2. Assets de Interface do Usuário (UI/UX)** {#6.2.-assets-de-interface-do-usuário-(ui/ux)}

A UI deve ser minimalista, funcional e, o mais importante, fácil de criar usando os recursos padrão da Unity.

* **Estilo UI:** **Clean / Minimalista Pós-Apocalíptico.**
    * *Justificativa:* O Vigilante é um agente de uma Ordem em ruínas; a UI deve parecer um **HUD funcional** e não uma
      decoração luxuosa.
* **Fontes (Fonts):**
    * **Recurso Free:** Utilize fontes de domínio público ou licenciadas como **OFL (Open Font License)**. Fontes
      *pixeladas* ou *monospaced* (como as usadas em terminais) são ótimas para o estilo "protocolo/relatório" e são
      facilmente encontradas.
    * *Sugestão de Busca:* Procure por fontes como **"Roboto Mono"** (Google Fonts) ou **"Press Start 2P"** (para um
      toque pixelado) que são gratuitas e com licença aberta.
* **Ícones e Elementos:**
    * **Recurso Free:** Use **ícones vetoriais** gratuitos (como o Font Awesome, que pode ser importado para alguns
      sistemas de UI da Unity, ou pacotes de ícones gratuitos no Asset Store). Se não encontrar, a melhor estratégia é
      usar **SÍMBOLOS:**
        * **HP/MP:** Barras simples (rectângulos) coloridas (HP: Vermelho, MP: Azul/Verde).
        * **Habilidades:** Ícones genéricos (um punho para Ataque Forte, um símbolo de raio para Especial, uma seta
          circular para Rola).
        * **Inventário/Documentos:** Use ícones de caixas (box) ou pergaminhos extremamente básicos feitos no
          Photoshop/GIMP com formas geométricas.
* **Câmera Isométrica e UI:** A UI deve ser fixa e não depender da rotação do mundo, o que simplifica o desenvolvimento.

### **6.3. Assets de Áudio e Música** {#6.3.-assets-de-áudio-e-música}

O áudio é essencial para o *game feel* e para quebrar a sensação de vazio do ambiente *low-poly*.

* **Música:**
    * **Recurso Free:** Utilize música licenciada sob **Creative Commons (CC0 ou CC BY)**.
    * **Estilo:** Música ambiente, drones longos, com tom sombrio e melancólico. Músicas não-melódicas são mais fáceis
      de encontrar gratuitamente.
    * *Sugestão de Busca:* "Dark Ambient CC0", "Royalty Free Horror Music".
* **Efeitos Sonoros (SFX):**
    * **Recurso Free:** Sites como **Freesound.org** (requer atribuição ou uso CC0).
    * **Prioridades de SFX (Essenciais para TDD/Game Feel):**
        1. **Ataque do Player:** Som forte de metal (impacto de espada/machado).
        2. **Dodge/Rola:** Som de energia cinética sendo liberada (um *whoosh* rápido).
        3. **Inimigos:** Um som de impacto genérico ao receber dano e um som distinto de *wind-up* antes de atacar (para
           dar ao Player o tempo de reação necessário para o **Dodge**).

---

## **8\. Atributos Iniciais e Balanceamento (Level 1\)** {#8.-atributos-iniciais-e-balanceamento-(level-1)}

O objetivo no Nível 1 é que o Vigilante seja **resiliente o suficiente** para sobreviver a alguns erros, mas *
*dependente de sua mecânica chave (Rolar/Desviar)** para o sucesso.

### **8.1. Atributos Base do Vigilante (Level 1\)** {#8.1.-atributos-base-do-vigilante-(level-1)}

| Atributo                 | Valor Base (LVL 1\) | Justificativa de Design                                                                                                                                                                                                |
|:-------------------------|:--------------------|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **HP (Pontos de Vida)**  | **100**             | Um valor *baseline* redondo. Permite ao Vigilante receber 3-4 hits de um inimigo de Fase 1 antes de morrer.                                                                                                            |
| **MP (Pontos de Magia)** | **40**              | Suficiente para **8 Roladas/Desvios** (5 MP de custo base) ou para **1 Ataque Especial** e sobrar MP para esquiva.                                                                                                     |
| **ATQ (Ataque)**         | **12**              | O dano básico deve ser moderado. Dano Básico inicial será [![][image7]](https://www.codecogs.com/eqnedit.php?latex=12%20%5Ctimes%201.0%20%3D%2012#0) de dano bruto.                                                    |
| **DEF (Defesa)**         | **10**              | Fornece **10% de mitigação de dano** ([![][image8]](https://www.codecogs.com/eqnedit.php?latex=1%20-%2010%2F100%20%3D%200.9#0)). Essencial para o TDD testar a fórmula de mitigação.                                   |
| **INT (Inteligência)**   | **5**               | O dano mágico (Especial) é baixo no início, focando o Player no combate físico. A INT inicial reduz o custo do Dodge em [![][image9]](https://www.codecogs.com/eqnedit.php?latex=5%20%5Ctimes%200.1%20%3D%200.5#0) MP. |

### **8.2. Resumo das Capacidades no Nível 1** {#8.2.-resumo-das-capacidades-no-nível-1}

Com os atributos acima, o *moveset* inicial do Vigilante será:

| Ação                | Custo de MP (Final)   | Dano Bruto (Inicial)                                                                                |
|:--------------------|:----------------------|:----------------------------------------------------------------------------------------------------|
| **Ataque Básico**   | 0 MP                  | **12** (Físico)                                                                                     |
| **Ataque Forte**    | 10 MP                 | **21.6** (Físico, [![][image10]](https://www.codecogs.com/eqnedit.php?latex=12%20%5Ctimes%201.8#0)) |
| **Rolar/Desviar**    | **4.5 MP** (5 \- 0.5) | N/A (Invencibilidade de 0.25s)                                                                      |
| **Ataque Especial** | 25 MP                 | **10** (Mágico, [![][image11]](http://www.texrendr.com/?eqn=5%20%5Ctimes%202.0%24\)#0)              |


## **10\. Estrutura de Progressão (Sistema de Nível)** {#10.-estrutura-de-progressão-(sistema-de-nível)}

Esta seção garante que o jogador tenha um senso de avanço claro e que a progressão seja limitada ao escopo do MVP (Nível
Máximo 5).

### **10.1. Progressão de Nível (LVL) e XP** {#10.1.-progressão-de-nível-(lvl)-e-xp}

O sistema será simples e linear, seguindo a filosofia do *Codex Tacticum* de foco em lógica e escopo restrito.

| Nível (LVL)        | XP Necessário para o Próximo LVL | XP Total Acumulado |
|:-------------------|:---------------------------------|:-------------------|
| **1**              | N/A (Ponto de Partida)           | 0                  |
| **2**              | **100**                          | 100                |
| **3**              | **200**                          | 300                |
| **4**              | **300**                          | 600                |
| **5 (Máximo MVP)** | **400**                          | 1000               |

*
**Regra de Aquisição de XP:**
    * **Inimigos Comuns:** 1-5 XP por Inimigo (dependendo da dificuldade).
    * **Mini-Bosses:** 50 XP.
    * **Boss da Fase:** 100 XP.
* **Justificativa de Balanceamento:** Com 5 Fases, o jogador deve atingir o LVL 5 antes ou logo após derrotar o Boss da
  Fase 4, para que possa enfrentar o Boss Final (Fase 5\) no nível máximo do MVP.

### **10.2. Crescimento Base de Atributos (Stats Base Growth)
** {#10.2.-crescimento-base-de-atributos-(stats-base-growth)}

A cada nível que o Vigilante sobe, seus atributos de sobrevivência (HP e MP) aumentam automaticamente.

| Atributo | Aumento por Nível (Automático) |
|:---------|:-------------------------------|
| **HP**   | **\+5** Pontos base.           |
| **MP**   | **\+2** Pontos base.           |

*
**Exemplo:** O Vigilante no LVL 5
terá [![][image12]](https://www.codecogs.com/eqnedit.php?latex=\(100%20%5Ctext%7B%20HP%20inicial%7D%20%2B%20\(4%20%5Ctext%7B%20n%C3%ADveis%20%7D%20%5Ctimes%205%20%5Ctext%7B%20HP%2Fn%C3%ADvel%7D\)\)
%20%3D%20120#0) HP base.

### **10.3. Distribuição de Pontos de Atributos (Player Choice)
** {#10.3.-distribuição-de-pontos-de-atributos-(player-choice)}

A cada nível, o jogador ganha pontos para distribuir livremente, focando nas *Stats* de combate.

* **Pontos por Nível:** O Player recebe **3 Pontos de Atributo** por nível (Total de 12 Pontos a serem distribuídos no
  MVP).
* **Atributos Distribuíveis:** **ATQ, DEF, INT.**
* **Justificativa de Design:** A alocação de pontos força o jogador a escolher um estilo de jogo:
    * **"Bruto" (ATQ Foco):** Mais dano Básico/Forte.
    * **"Místico" (INT Foco):** Mais dano Especial (AOE) e Roladas mais baratas (Mais sobrevivência tática).
    * **"Tanque" (DEF Foco):** Mais mitigação, mas menos dano.

### **10.4. Exemplo de *Build* Final (LVL 5\)** {#10.4.-exemplo-de-build-final-(lvl-5)}

| Atributo | Valor Inicial (LVL 1\) | Ganhos Automáticos | Pontos Distrib. (Máximo 12\) | Valor Final (Exemplo) |
|:---------|:-----------------------|:-------------------|:-----------------------------|:----------------------|
| **HP**   | 100                    | \+20               | N/A                          | **120**               |
| **MP**   | 40                     | \+8                | N/A                          | **48**                |
| **ATQ**  | 12                     | N/A                | Ex: \+6                      | **18**                |
| **DEF**  | 10                     | N/A                | Ex: \+3                      | **13% Mitig.**        |
| **INT**  | 5                      | N/A                | Ex: \+3                      | **8**                 |

## **12\. Design de Inimigos (Os Constructos de Cinza)** {#12.-design-de-inimigos-(os-constructos-de-cinza)}

Todos os inimigos são **Constructos de Cinza** (modelos *low-poly* genéricos com *shader* de cinza). Eles atacam o
Vigilante, mas não usam MP; em vez disso, suas ações são limitadas por *cooldown* e padrões previsíveis, facilitando o
teste e a estratégia do jogador.

### **A. Inimigos Comuns (Fase 1 a 3\)** {#a.-inimigos-comuns-(fase-1-a-3)}

| Inimigo (Asset Free)    | Tipo          | Stats (LVL 1\)            | Padrão de Ataque (O que o TDD testa)                                                                                                                                 |
|:------------------------|:--------------|:--------------------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Pária de Cinza**      | Melee (Tank)  | HP: 30 / ATQ: 5 / DEF: 15 | **Ataque Lento de 1 Hit:** Caminha lentamente em direção ao Player. Sua alta DEF força o Player a usar o **Ataque Forte** (alto dano de ATQ) para matar rapidamente. |
| **Vigia de Estilhaços** | Ranged        | HP: 15 / ATQ: 8 / DEF: 5  | **Projetil Previsível:** Atira um projétil lento a cada 2.5s. Sua baixa HP/DEF faz dele um alvo fácil, mas o projétil força o Player a usar a **Rolar/Desviar**.      |
| **Slime de Cinza**      | Swarm (Horda) | HP: 8 / ATQ: 3 / DEF: 0   | **Ataque em Grupo:** Movem-se rapidamente em direção ao Player, causando pouco dano. Força o Player a usar o **Ataque Especial** (AOE, dano INT).                    |

### **B. Mini-Bosses e Bosses (Fase 1 a 3\)** {#b.-mini-bosses-e-bosses-(fase-1-a-3)}

| Boss                  | Fase | Design e Função Tática                                                                                                                                                                                         | Stats (Aumento de Dificuldade) |
|:----------------------|:-----|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-------------------------------|
| **O Golem Lento**     | 1    | **Teste de ATQ/DEF:** Versão gigante do Pária. Muito lento, mas com HP e DEF altíssimos. Seu único ataque é um *slam* telegrafado, forçando o *Dodge*.                                                         | HP: 300 / ATQ: 10 / DEF: 30    |
| **O Tático de Cinza** | 2    | **Teste de Rolar/Desviar e Priorização:** Não ataca o Player, mas invoca constantemente (a cada 5s) Vigias de Estilhaços (Ranged). Derrotá-lo exige que o Player **priorize a esquiva e o Tático** rapidamente. | HP: 150 / ATQ: 0 / DEF: 10     |
| **A Matriz**          | 3    | **Teste de INT/MP e AOE:** Estrutura estática que lança uma onda de Slimes de Cinza. O Player deve usar o **Ataque Especial** consistentemente para limpar a área antes de atacar a Matriz.                    | HP: 250 / ATQ: 0 / DEF: 15     |

---

## **13\. Mecânicas Opcionais (Detalhando Áreas e Documentos)
** {#13.-mecânicas-opcionais-(detalhando-áreas-e-documentos)}

TODO

### **13.1. Áreas Secretas (Baixo Custo de Desenvolvimento)** {#13.1.-áreas-secretas-(baixo-custo-de-desenvolvimento)}

* **Objetivo:** Recompensar a exploração e quebrar a linearidade do *dungeon crawler*.
* **Mecanismo:** As áreas secretas serão acessadas por **"Fragmentos da Ordem"**.
    * **Mecanismo Simples:** Uma porta ou parede deve ter um *collider* que só é ativado se o Player estiver com o
      item "Fragmento da Ordem" no inventário.
    * **Recompensa:** Dentro, o Player encontrará um **Documento de História** e/ou um **Cristal de Status** (consumível
      que dá \+1 permanentemente a ATQ, DEF ou INT).
* **Foco do TDD:** O teste deve apenas garantir que o *collider* da porta funcione e que o Player só possa entrar se a *
  *Condição de Item** for verdadeira.

### **13.2. Documentos (Lore e Justificativa)** {#13.2.-documentos-(lore-e-justificativa)}

* **Formato:** Arquivos de texto simples (TXT ou JSON) no projeto que são exibidos em uma janela de **"Relatório de
  Dados"** na UI.
* **Conteúdo:** "Registros de Batalha de um Antecessor" ou "Relatórios de Análise de Cinzas".
    * **Regra de História:** Os documentos devem fornecer **dicas táticas** para o jogo (Ex: *"...o Golem Lento não
      sente dor, mas o impacto concentrado quebra sua carapaça"* – Dica para usar o Ataque Forte) e aprofundar a
      história da Ordem.
* **Mecanismo:** O Player interage com um *prop* no mundo (ex: um Tablet, um Pergaminho), que salva o Documento em sua *
  *Codex**.
* **Foco do TDD:** O teste deve confirmar que a **Codex UI** é populada corretamente com o texto do arquivo e que o
  documento não desaparece após ser lido.

---

##  

[image1]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAIUAAAAwBAMAAADN86TJAAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAie92mbur3SIyZs0QRFQASZskAAAANklEQVR4Xu3MoQHAIADAsLH/n+UC0J0cBpHIio71nJrvt/zgUR7lUR7lUR7lUR7lUR7lUbc8NuY0AlCE1OfXAAAAAElFTkSuQmCC>

[image2]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAG0AAAAVBAMAAAC+p33JAAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAdu/dIomrMhBEZpnNu1TMZGYvAAAAIUlEQVR4XmP8z0AO+MiELkIkGNWHHYzqww5G9WEHw10fABdRAhpje4JJAAAAAElFTkSuQmCC>

[image3]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAG0AAAAVBAMAAAC+p33JAAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAdu/dIomrMhBEZpnNu1TMZGYvAAAAIUlEQVR4XmP8z0AO+MiELkIkGNWHHYzqww5G9WEHw10fABdRAhpje4JJAAAAAElFTkSuQmCC>

[image4]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACsAAAAQBAMAAAB9zpudAAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAie92mbur3TLNRFRmECLP1ybXAAAAGElEQVR4XmP8z4AFfGRCF4GAUWFMQJowAMvZAhA6LSg+AAAAAElFTkSuQmCC>

[image5]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGwAAAAQBAMAAAABqIdEAAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAdu/dzburIlQQRGaJmTJeu5QvAAAAHElEQVR4XmP8z0AOYEIXIA6MasMAo9owwHDWBgCmLgEfJ0bgGQAAAABJRU5ErkJggg==>

[image6]: <data:image/png;base64,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>

[image7]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAIUAAAAQBAMAAADKX6H/AAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAdu9mmRC7RM1UMiKJq90p5NcAAAAAIUlEQVR4XmP8z0Ap+MiELkIGGDUDFYyagQpGzUAFg8UMAESmAhBP6UVmAAAAAElFTkSuQmCC>

[image8]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAKgAAAAYBAMAAACcr6vyAAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAdu9mmRC7RM1UMiKJq90p5NcAAAAAKklEQVR4XmP8z0B9wIQuQA0waij1waih1AejhlIfjBpKfTBqKPXB0DEUALa5AS/Ttjz7AAAAAElFTkSuQmCC>

[image9]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAIEAAAAQBAMAAADDtAGFAAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAiasy791mELtUmc1EInbPtqVlAAAAIUlEQVR4XmP8z0AZ+MiELkIyGDUBAkZNgIBREyBgMJgAAAZoAhCujKi0AAAAAElFTkSuQmCC>

[image10]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAE8AAAAQBAMAAAClwj+XAAAAMFBMVEX///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAv3aB7AAAAD3RSTlMAdu9mmRC7RM1UMiKJq90p5NcAAAAAGklEQVR4XmP8z0AU+MiELoILjCrEC0YV4gUA/CUCEEwcs50AAAAASUVORK5CYII=>

[image11]: <data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAE8AAAAYBAMAAABJkb36AAAAMFBMVEX////V1dXKysq/v7+pqalubm5hYWFUVFRGRkY4ODgoKCgYGBgAAAAAAAAAAAAAAAB3TM3pAAAAAXRSTlMAQObYZgAAAZVJREFUeF6NUr9Lw0AU/hpCuELj6j/hUHDQweEWQQdXEVwySUGHgA663dChoGBAXZziIuLk1goKN4kOQv8EN2eNcCEE9L1L2sSCth8k79d37+V7ucY3puNzDh/OZHIC5lICDXIchEBQK0CWXsDZ5Ghn0IYfMTFCHle8dawU3n58poDVCII67TLxIT8Y8yA1uoodswFfAh1y54Gcxv8Wo8MhTLMMMq8qjMWEhZFDYMQD8bKRjxFxjZ40RtgmOQx7MMR12UDT6MTfvCVST2HAbGRPsigyUlHOp9GPuFKAWET6bFPeXcWD0F6frSnEfLVIWDft2dphYUbIvJC2WIoR9Lj2zcNqLIKXdq21RLdWaKtawBAta5y8jHOkbJKtIpTjVwnH1cW2+kopMoHCEuc17WVP28O8LwMnk5aYvkIsU+YVeIEJkZOCY+CGUvfgn+B4CtkJdaB2MsbCGy+3GcFoPoFtasGDNIl5R0zugCIR4Bz8ZbmG30FK00ny6dDmJi7Fn5h6wwuY6lL8D3dW4sWMxCSckciCfwBg9XyyMbV00gAAAABJRU5ErkJggg==>

[image12]: <data:image/png;base64,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>