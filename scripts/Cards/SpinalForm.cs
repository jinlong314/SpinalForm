using System.Collections.Generic;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using STS2RitsuLib.Scaffolding.Content;
using SpinalFormMod.Powers;

namespace SpinalFormMod.Cards;

[RegisterCard(typeof(DefectCardPool))]
public sealed class SpinalForm : ModCardTemplate
{
    protected override List<DynamicVar> CanonicalVars => new()
    {
        new PowerVar<SpinalFormPower>(1m)
    };

    public SpinalForm() : base(
        cost: 3,
        type: CardType.Power,
        rarity: CardRarity.Rare,
        target: TargetType.Self)
    { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<SpinalFormPower>(
            choiceContext,
            Owner.Creature,
            DynamicVars[nameof(SpinalFormPower)].BaseValue,
            Owner.Creature,
            this);
    }

    protected override void OnUpgrade()
    {
        DynamicVars[nameof(SpinalFormPower)].UpgradeValueBy(1m);
    }
}
