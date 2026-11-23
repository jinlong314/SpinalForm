using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;
using STS2RitsuLib.Interop.AutoRegistration;

namespace SpinalForm.Powers;

[RegisterPower]
public sealed class SpinalFormPower : PowerModel
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public override bool IsInstanced => false;
    public override bool AllowNegative => false;

    private int _clawCount;

    public override async Task AfterCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
    {
        if (cardPlay.Card.Owner?.Creature != Owner) return;
        if (cardPlay.Card.Id.Entry != "CLAW") return;

        _clawCount++;
        if (_clawCount < 3) return;

        _clawCount = 0;
        Flash();

        // 1. 将这张爪击返回手牌
        await CardPileCmd.AddGeneratedCardToCombat(
            cardPlay.Card, PileType.Hand, Owner);

        // 2. 直接增加重放层数
        cardPlay.Card.ReplayCount += (int)Amount;
    }
}
