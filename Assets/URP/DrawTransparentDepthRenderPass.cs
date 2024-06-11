using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace GraphicExtention.PostProcessing.TransparentDepthTexture
{
    /// <summary>
    ///     Path that grabs the color texture of the camera.
    /// </summary>
    public class DrawTransparentDepthRenderPass : ScriptableRenderPass
    {
        // Depth Bufferを32bitにする
        int kDepthBufferBits = 32;

        // RenderTextureの識別用struct
        private RenderTargetHandle depthAttachmentHandle { get; set; }
        // 作成するRenderTextureの情報を入れるstruct
        internal RenderTextureDescriptor descriptor { get; private set; }

        FilteringSettings m_FilteringSettings;
        const string m_ProfilerTag = "Transparent Depth Prepass";
        ProfilingSampler m_ProfilingSampler = new ProfilingSampler(m_ProfilerTag);
        ShaderTagId m_ShaderTagId = new ShaderTagId("DepthOnly");

        private RenderTargetHandle m_transparentDepthTexture;

        private RenderQueueRange m_renderQueueRange;

        public DrawTransparentDepthRenderPass(RenderPassEvent evt, RenderQueueRange renderQueueRange)
        {
            m_renderQueueRange = renderQueueRange;
            renderPassEvent = evt;
        }

        // パスで使用するテクスチャなどの設定
        public void Setup(RenderTextureDescriptor baseDescriptor)
        {
            m_transparentDepthTexture.Init("_CameraTransparentDepthTexture");

            // カメラからのテクスチャをデプステクスチャ用に設定
            this.depthAttachmentHandle = m_transparentDepthTexture;
            baseDescriptor.colorFormat = RenderTextureFormat.Depth;
            baseDescriptor.depthBufferBits = kDepthBufferBits;

            // Depth-Only pass don't use MSAA
            baseDescriptor.msaaSamples = 1;

            descriptor = baseDescriptor;
        }

        // This method is called before executing the render pass.
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            cmd.GetTemporaryRT(depthAttachmentHandle.id, descriptor, FilterMode.Point);
            ConfigureTarget(depthAttachmentHandle.Identifier());
            ConfigureClear(ClearFlag.All, Color.black);
        }

        // Here you can implement the rendering logic.
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get(m_ProfilerTag);

            using (new ProfilingScope(cmd, m_ProfilingSampler))
            {
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                var sortFlags = renderingData.cameraData.defaultOpaqueSortFlags;
                m_FilteringSettings = new FilteringSettings(m_renderQueueRange);
                var drawSettings = CreateDrawingSettings(m_ShaderTagId, ref renderingData, sortFlags);
                drawSettings.perObjectData = PerObjectData.None;

                ref CameraData cameraData = ref renderingData.cameraData;
                Camera camera = cameraData.camera;

                context.DrawRenderers(renderingData.cullResults, ref drawSettings, ref m_FilteringSettings);

            }
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        // Cleanup any allocated resources that were created during the execution of this render pass.
        public override void FrameCleanup(CommandBuffer cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException("cmd");

            if (depthAttachmentHandle != RenderTargetHandle.CameraTarget)
            {
                cmd.ReleaseTemporaryRT(depthAttachmentHandle.id);
                depthAttachmentHandle = RenderTargetHandle.CameraTarget;
            }
        }
    }
}
