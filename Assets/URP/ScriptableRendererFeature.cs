using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace GraphicExtention.PostProcessing.TransparentDepthTexture
{
    /// <summary>
    ///     Renderer feature to grab color texture and render objects that use it.
    /// </summary>
    [Serializable]
    [CreateAssetMenu(fileName = "aa",menuName = "aa")]
    public class DrawTransparentDepthRendererFeature : ScriptableRendererFeature
    {
        private DrawTransparentDepthRenderPass pass;

        public override void Create()
        {

        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            pass ??= new DrawTransparentDepthRenderPass(RenderPassEvent.AfterRenderingTransparents, RenderQueueRange.all);
            pass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;

            var cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
            pass.Setup(cameraTargetDescriptor);
            if (pass != null)
            {
                renderer.EnqueuePass(pass);
            }
        }
    }
}
