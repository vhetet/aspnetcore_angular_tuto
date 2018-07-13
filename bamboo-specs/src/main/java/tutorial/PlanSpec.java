package tutorial;

import com.atlassian.bamboo.specs.api.BambooSpec;
import com.atlassian.bamboo.specs.api.builders.BambooKey;
import com.atlassian.bamboo.specs.api.builders.BambooOid;
import com.atlassian.bamboo.specs.api.builders.plan.Job;
import com.atlassian.bamboo.specs.api.builders.plan.Plan;
import com.atlassian.bamboo.specs.api.builders.plan.PlanIdentifier;
import com.atlassian.bamboo.specs.api.builders.plan.Stage;
import com.atlassian.bamboo.specs.api.builders.plan.branches.BranchCleanup;
import com.atlassian.bamboo.specs.api.builders.project.Project;
import com.atlassian.bamboo.specs.builders.task.ScriptTask;
import com.atlassian.bamboo.specs.builders.task.VcsCheckoutTask;
import com.atlassian.bamboo.specs.builders.trigger.RepositoryPollingTrigger;
import com.atlassian.bamboo.specs.model.task.ScriptTaskProperties;
import com.atlassian.bamboo.specs.util.BambooServer;

@BambooSpec
public class PlanSpec {
    
    public Plan plan() {
        final Plan plan = new Plan(new Project()
                .oid(new BambooOid("1bz9puf97pu69"))
                .key(new BambooKey("TES"))
                .name("testBamboo")
                .description("Project to experiment with bamboo"),
            "testBamboo",
            new BambooKey("TES"))
            .oid(new BambooOid("1bz00mtvzw1s1"))
            .description("Plan to experiment with bamboo")
            // .pluginConfigurations(new ConcurrentBuilds()
            //         .useSystemWideDefault(false))
            .stages(new Stage("Default Stage")
                    .jobs(new Job("Default Job",
                            new BambooKey("JOB1"))
                            .tasks(new VcsCheckoutTask()
                                    .description("Checkout Default Repository"),
                                    // .checkoutItems(new CheckoutItem().defaultRepository()),
                                new ScriptTask()
                                    .description("build")
                                    .interpreter(ScriptTaskProperties.Interpreter.BINSH_OR_CMDEXE)
                                    .inlineBody("dotnet build ${bamboo.build.working.directory}/vega.csproj"),
                                new ScriptTask()
                                    .description("test")
                                    .interpreter(ScriptTaskProperties.Interpreter.BINSH_OR_CMDEXE)
                                    .inlineBody("dotnet test ${bamboo.build.working.directory}/vega.csproj --no-build"),
                                new ScriptTask()
                                    .description("pack")
                                    .inlineBody("dotnet pack ${bamboo.build.working.directory}/vega.csproj --no-build"))))
            .linkedRepositories("net core / angular tuto")
            
            .triggers(new RepositoryPollingTrigger());
            // .planBranchManagement(new PlanBranchManagement()
            //         .delete(new BranchCleanup())
            //         .notificationForCommitters());
        return plan;
    }
    
    // public PlanPermissions planPermission() {
    //     final PlanPermissions planPermission = new PlanPermissions(new PlanIdentifier("TES", "TES"))
    //         .permissions(new Permissions()
    //                 .userPermissions("vincenthetet", PermissionType.EDIT, PermissionType.VIEW, PermissionType.ADMIN, PermissionType.CLONE, PermissionType.BUILD));
    //     return planPermission;
    // }
    
    public static void main(String... argv) {
        //By default credentials are read from the '.credentials' file.
        BambooServer bambooServer = new BambooServer("http://10.10.194.104:8085");
        final PlanSpec planSpec = new PlanSpec();
        
        final Plan plan = planSpec.plan();
        bambooServer.publish(plan);
        
        // final PlanPermissions planPermission = planSpec.planPermission();
        // bambooServer.publish(planPermission);
    }
}