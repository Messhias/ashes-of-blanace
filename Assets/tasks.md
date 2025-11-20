## **16\. Cronograma de Implementação TDD (Novembro a Fevereiro)**

**Objetivo:** Entregar o MVP 1.0 de "Ashes of Balance" (5 Fases, Combate Completo) com Arquitetura Limpa e Testes Unitários.

| Mês | Semana (Sprint) | Foco Principal (Camada) | Entregável da Semana (Teste \+ Funcionalidade) | Status |
| :---- | :---- | :---- | :---- | :---- |
| **Novembro** | **S1: Domínio Core** | **Domínio (C\# Pura)** | **Entidades: Vigilante, Stats, DanoFormula.** Todas as regras de combate do GDD testadas (Dano, Mitigação, HP/MP). | **DONE** |
|  | **S2: Casos de Uso** | **Aplicação (C\# Pura)** | **Casos de Uso: Attack/Dodge/SpecialUseCases.** A lógica de *cooldown* e custo de MP testada. | **DONE** |
|  | **S3: Base da Engine** | **Infraestrutura (Unity)** | **PlayerController (MB Magro)**, carregando CombatStatsSO. **Movimento Isométrico** funcional e testado. | **DONE** |
|  | **S4: Combate Básico** | **Infraestrutura (Unity)** | **Ataque Básico/Forte (Visual/SFX) e Combate Unidirecional (Player \-\> Inimigo).** | **IN PROGRESS** |
| **Dezembro** | **S5: Core Loop** | **Integração/Aplicação** | **Inimigo Base (Pária) Funcional.** **Teste de Ciclo:** Pária ataca (dano) e Player ataca (mitigação) com Rola. | **TODO** |
|  | **S6: UI e Feedback** | **Infraestrutura/UI** | **HUD de HP/MP/CD (barras simples) funcional.** Subscrevendo a eventos do Domínio (Ex: Vigilante.OnHPChanged). | **TODO** |
|  | **S7: Level Up/XP** | **Domínio/Aplicação** | **Lógica de XP/Level Up/Distribuição de Stats testada.** Menu de Level Up funcional (UI). | **TODO** |
|  | **S8: Mini-Boss 1** | **Integração/Fase 1** | **Fase 1 (O Grito das Raízes) finalizada.** **O Golem Lento (Mini-Boss 1\)** implementado. | **TODO** |
| **Janeiro** | **S9: Mecânica Ranged** | **Domínio/Aplicação** | **Inimigo Vigia de Estilhaços (Ranged) e Lógica de Projétil testados.** Player forçado a usar **Rola/Desviar**. | **TODO** |
|  | **S10: Boss/Tático** | **Fase 2** | **Fase 2 (O Pântano dos Vigias) finalizada.** **O Tático de Cinza (Mini-Boss 2\)** (Lógica de Invocação). | **TODO** |
|  | **S11: Mecânica AOE** | **Domínio/Aplicação** | **Inimigo Slime de Cinza (Horda) e Ataque Especial (AOE) testados.** | **TODO** |
|  | **S12: Final Boss** | **Fase 3/4** | **Fase 3 (Matriz) e Fase 4 (Caçador Veloz) em *whitebox*.** Bosses com lógica de ataque complexa. | **TODO** |
| **Fevereiro** | **S13: Conteúdo Final** | **Integração/Final** | **Fase 5 (Boss Final) finalizada.** **Opcionais (Documentos e Áreas Secretas)** implementados. | **TODO** |
|  | **S14: Polimento/Arte** | **Infraestrutura/Entrega** | **Finalização de Assets/UI/SFX (com os assets free).** Refinamento final e *Build* do MVP 1.0. | **TODO** |

---

## 