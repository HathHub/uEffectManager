using SDG.NetTransport;
using SDG.Unturned;
using Steamworks;
using UnityEngine;
using System;
using uScript.API.Attributes;
using uScript.Core;
using uScript.Module.Main.Classes;

[ScriptModule("uEffectManager")]
public class uEffects
{
    [ScriptFunction("triggerEffect")]
    public static void TriggerEffect( ushort id, float range, Vector3Class position)
    {
            var asset = Assets.find(EAssetType.EFFECT, id);
            var eff = new TriggerEffectParameters((EffectAsset)asset)
            {
                relevantDistance = range,
                position = position.Vector3
            };
            EffectManager.triggerEffect(eff);
    }

    [ScriptFunction("ClearEffectByGuid")]
    public static void ClearEffectByGuid(ushort id, string playerId)
    {
            ITransportConnection transportConnection = Provider.findTransportConnection(new CSteamID(ulong.Parse(playerId)));
        var asset = Assets.find(EAssetType.EFFECT, id);
        EffectManager.ClearEffectByGuid(asset.GUID ,transportConnection);
    }
    [ScriptFunction("askEffectClearByID")]
    public static void askEffectClearByID( ushort id, string playerId)
    {
            ITransportConnection transportConnection = Provider.findTransportConnection(new CSteamID(ulong.Parse(playerId)));
            EffectManager.askEffectClearByID(id, transportConnection);
    }
    [ScriptFunction("ClearEffectByID_AllPlayers")]
    public static void ClearEffectByID_AllPlayers(ushort id)
    {
        EffectManager.ClearEffectByID_AllPlayers(id);
    }
    [ScriptFunction("ClearEffectByGuid_AllPlayers")]
    public static void ClearEffectByGuid_AllPlayers(ushort id)
    {
        var asset = Assets.find(EAssetType.EFFECT, id);
        EffectManager.ClearEffectByGuid_AllPlayers(asset.GUID);
    }
}