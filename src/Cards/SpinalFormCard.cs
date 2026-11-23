using System.Collections.Generic;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.CardPools;
using STS2RitsuLib.Scaffolding.Content;
using STS2RitsuLib.Interop.AutoRegistration;
using SpinalForm.Powers;

namespace SpinalForm.Cards;

[RegisterCard(typeof(DefectCardPool))]
public sealed class SpinalFormCard : ModCardTemplate(3, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override List<DynamicVar> CanonicalVars => new()
    {
        new PowerVar<SpinalFormPower>(1m)
    };

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
