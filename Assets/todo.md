4. CombatStatsSo não inicializa CurrentMP
   Problema: CurrentMP não é setado no método ToDomainStats()
   Arquivo: Infrastructure/ScriptableObjects/CombatStatsSo.cs linha 35-43
   Impacto: MP inicial pode estar zerado
   Médias (afetam comportamento/corretude)

5. OnDamageTaken passa dano bruto ao invés de dano final
   Problema: evento dispara com damage (bruto) em vez de finalDamage (após mitigação)
   Arquivo: Domain/Combat/CombatantEntity.cs linha 56
   Impacto: UI/feedback podem mostrar valores incorretos

6. DodgeService não valida custo mínimo
   Problema: se INT for muito alta, finalCost pode ficar negativo
   Arquivo: Application/DodgeService.cs linha 14
   Solução: usar Mathf.Max(0, finalCost)

7. CombatantEntity não inicializa LastActionTime
   Problema: LastActionTime não é inicializado no construtor
   Arquivo: Domain/Combat/CombatantEntity.cs linha 29-43
   Impacto: primeira ação pode falhar na verificação de cooldown
   Planejadas (sprints futuras)

8. Sistema de Level Up/XP não implementado
   GDD: Seção 10 (Progressão de Nível, XP, Distribuição de Pontos)
   Status: planejado para Sprint S7 (TODO)
------


Testes que faltam:

Teste para DEF máxima (70 DEF)
Onde: DamageFormulaTests.cs
GDD 4.4 menciona: "O TDD deve incluir um caso de teste para a DEF máxima (ex: 70 DEF), confirmando que 30% do dano bruto é aplicado."
Status: Falta
Teste de regeneração passiva de MP
Onde: CombatantEntityTests.cs ou novo arquivo
GDD 4.1 menciona: "Teste de Regeneração de MP"
GDD 3 menciona: "O Teste de Recurso deve garantir que... a regeneração passiva de MP funcione."
Status: Falta

-x-x-x

StrongAttackServiceTests.cs (Ataque Forte)
GDD 4.2 define:
Custo: 10 MP
Cooldown: 3.0s
Dano: ATQ × 1.8
tasks.md S2 menciona: "Casos de Uso: Attack/Dodge/SpecialUseCases"
Status: Falta
SpecialAttackServiceTests.cs (Ataque Especial)
Onde: Tests/
GDD 4.2 define:
Custo: 25 MP
Cooldown: 8.0s
Dano: INT × 2.0 (mágico, AOE)
tasks.md S2 menciona: "SpecialUseCases"
Status: Falta
